using System.Collections.Generic;
using System.Linq;
using GraphProcessor;
using UnityEngine;

namespace GAS.Runtime
{
    public class AbilityGraphProcessor : BaseGraphProcessor
    {
        List<BaseNode> m_ProcessList;
        List<OnActivateNode> m_OnActivateNodes;

        Dictionary<BaseNode, List<BaseNode>> m_NonConditionalDependenciesCache =
            new Dictionary<BaseNode, List<BaseNode>>();

        public bool pause;

        public IEnumerator<BaseNode> CurrentGraphExecution { get; private set; } = null;

        /// <summary>
        /// Manage graph scheduling and processing
        /// </summary>
        /// <param name="graph">Graph to be processed</param>
        public AbilityGraphProcessor(AbilityGraph graph) : base(graph)
        {
        }

        public override void UpdateComputeOrder()
        {
            // Gather start nodes:
            m_OnActivateNodes = graph.nodes.OfType<OnActivateNode>().ToList();

            // In case there is no start node, we process the graph like usual
            if (m_OnActivateNodes.Count == 0)
            {
                m_ProcessList = graph.nodes.OrderBy(n => n.computeOrder).ToList();
            }
            else
            {
                m_NonConditionalDependenciesCache.Clear();
                // Prepare the cache of non-conditional node execution
            }
        }

        public override void Run()
        {
            IEnumerator<BaseNode> enumerator;

            if (m_OnActivateNodes.Count == 0)
            {
                enumerator = RunTheGraph();
            }
            else
            {
                Stack<BaseNode> nodeToExecute = new Stack<BaseNode>();
                // Add all the start nodes to the execution stack
                m_OnActivateNodes.ForEach(s => nodeToExecute.Push(s));
                // Execute the whole graph:
                enumerator = RunTheGraph(nodeToExecute);
            }

            while (enumerator.MoveNext())
                ;
        }

        private void WaitedRun(Stack<BaseNode> nodesToRun)
        {
            // Execute the waitable node:
            var enumerator = RunTheGraph(nodesToRun);

            while (enumerator.MoveNext())
                ;
        }

        IEnumerable<BaseNode> GatherNonConditionalDependencies(BaseNode node)
        {
            Stack<BaseNode> dependencies = new Stack<BaseNode>();

            dependencies.Push(node);

            while (dependencies.Count > 0)
            {
                var dependency = dependencies.Pop();

                foreach (var d in dependency.GetInputNodes().Where(n => !(n is IConditionalNode)))
                    dependencies.Push(d);

                if (dependency != node)
                    yield return dependency;
            }
        }

        private IEnumerator<BaseNode> RunTheGraph()
        {
            int count = m_ProcessList.Count;

            for (int i = 0; i < count; i++)
            {
                m_ProcessList[i].OnProcess();
                yield return m_ProcessList[i];
            }
        }

        private IEnumerator<BaseNode> RunTheGraph(Stack<BaseNode> nodeToExecute)
        {
            HashSet<BaseNode> nodeDependenciesGathered = new HashSet<BaseNode>();
            HashSet<BaseNode> skipConditionalHandling = new HashSet<BaseNode>();

            while (nodeToExecute.Count > 0)
            {
                var node = nodeToExecute.Pop();
                // TODO: maxExecutionTimeMS

                // In case the node is conditional, then we need to execute it's non-conditional dependencies first
                if (node is IConditionalNode && !skipConditionalHandling.Contains(node))
                {
                    // Gather non-conditional deps: TODO, move to the cache:
                    if (nodeDependenciesGathered.Contains(node))
                    {
                        // Execute the conditional node:
                        node.OnProcess();
                        yield return node;

                        // And select the next nodes to execute:
                        switch (node)
                        {
                            // special code path for the loop node as it will execute multiple times the same nodes
                            case ForLoopNode forLoopNode:
                                forLoopNode.index = forLoopNode.start - 1; // Initialize the start index
                                foreach (var n in forLoopNode.GetExecutedNodesLoopCompleted())
                                    nodeToExecute.Push(n);
                                for (int i = forLoopNode.start; i < forLoopNode.end; i++)
                                {
                                    foreach (var n in forLoopNode.GetExecutedNodesLoopBody())
                                        nodeToExecute.Push(n);

                                    nodeToExecute.Push(node); // Increment the counter
                                }

                                skipConditionalHandling.Add(node);
                                break;
                            // another special case for waitable nodes, like "wait for a coroutine", wait x seconds", etc.
                            case WaitableNode waitableNode:
                                foreach (var n in waitableNode.GetExecutedNodes())
                                    nodeToExecute.Push(n);

                                waitableNode.onProcessFinished += (waitedNode) =>
                                {
                                    Stack<BaseNode> waitedNodes = new Stack<BaseNode>();
                                    foreach (var n in waitedNode.GetExecuteAfterNodes())
                                        waitedNodes.Push(n);
                                    WaitedRun(waitedNodes);
                                    waitableNode.onProcessFinished = null;
                                };
                                break;
                            case IConditionalNode cNode:
                                foreach (var n in cNode.GetExecutedNodes())
                                    nodeToExecute.Push(n);
                                break;
                            default:
                                Debug.LogError($"Conditional node {node} not handled");
                                break;
                        }

                        nodeDependenciesGathered.Remove(node);
                    }
                    else
                    {
                        nodeToExecute.Push(node);
                        nodeDependenciesGathered.Add(node);
                        foreach (var nonConditionalNode in GatherNonConditionalDependencies(node))
                        {
                            nodeToExecute.Push(nonConditionalNode);
                        }
                    }
                }
                else
                {
                    node.OnProcess();
                    yield return node;
                }
            }
        }

        // Advance the execution of the graph of one node, mostly for debug. Doesn't work for WaitableNode's executeAfter port.
        public void Step()
        {
            if (CurrentGraphExecution == null)
            {
                Stack<BaseNode> nodeToExecute = new Stack<BaseNode>();
                if (m_OnActivateNodes.Count > 0)
                    m_OnActivateNodes.ForEach(s => nodeToExecute.Push(s));

                CurrentGraphExecution = m_OnActivateNodes.Count == 0 ? RunTheGraph() : RunTheGraph(nodeToExecute);
                CurrentGraphExecution.MoveNext(); // Advance to the first node
            }
            else if (!CurrentGraphExecution.MoveNext())
                CurrentGraphExecution = null;
        }
    }
}