using System.Collections.Generic;
using System.Linq;
using GraphProcessor;
using UnityEngine;

namespace GAS.Runtime
{
    public class Ability : BaseGraphProcessor
    {
        protected AbilityGraph Graph { get; }
        public AbilitySystem Owner { get; private set; }
        public string Name { get; private set; }
        private readonly List<OnActivateNode> m_OnActivateNodes = new List<OnActivateNode>();

        /// <summary>
        /// Manage graph scheduling and processing
        /// </summary>
        /// <param name="graph">Graph to be processed</param>
        public Ability(AbilityGraph graph) : base(graph)
        {
            Name = graph.name;
            Graph = graph;
            InitNodes();
        }

        public Ability(AbilityGraph graph, AbilitySystem owner) : base(graph)
        {
            Name = graph.name;
            Graph = graph;
            Owner = owner;
            InitNodes();
        }

        private void InitNodes()
        {
            foreach (var node in Graph.nodes)
            {
                switch (node)
                {
                    case OnActivateNode onActivateNode:
                        m_OnActivateNodes.Add(onActivateNode);
                        break;
                }
            }
        }

        public virtual void SetOwner(AbilitySystem owner)
        {
            Owner = owner;
        }

        private void OnActivate()
        {
            if (m_OnActivateNodes.Count == 0)
            {
                return;
            }

            Stack<BaseNode> nodeToExecute = new Stack<BaseNode>();
            // Add all the start nodes to the execution stack
            m_OnActivateNodes.ForEach(s => nodeToExecute.Push(s));
            // Execute the whole graph:
            IEnumerator<BaseNode> enumerator = RunTheGraph(nodeToExecute);
            while (enumerator.MoveNext()) ;
        }

        public bool TryActivate()
        {
            OnActivate();
            return true;
        }

        private void WaitedRun(Stack<BaseNode> nodesToRun)
        {
            // Execute the waitable node:
            var enumerator = RunTheGraph(nodesToRun);
            while (enumerator.MoveNext()) ;
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

        public override void UpdateComputeOrder()
        {
        }

        public override void Run()
        {
        }
    }
}