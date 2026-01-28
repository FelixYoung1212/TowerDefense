using System.Collections;
using System.Collections.Generic;
using XNode;

namespace GAS.Runtime
{
    /// <summary>
    /// 能力类
    /// </summary>
    public class Ability
    {
        protected AbilityGraph Graph { get; private set; }
        public AbilitySystem Owner { get; private set; }
        public string Name { get; private set; }
        private readonly List<OnActivateNode> m_OnActivateNodes = new List<OnActivateNode>();

        protected Ability(AbilityGraph graph)
        {
            Name = graph.name;
            Graph = graph;
        }

        protected Ability(AbilityGraph graph, AbilitySystem owner)
        {
            Name = graph.name;
            Graph = graph;
            Owner = owner;
        }

        protected void InitNodes()
        {
            foreach (var node in Graph.nodes)
            {
                if (node is OnActivateNode onActivateNode)
                {
                    m_OnActivateNodes.Add(onActivateNode);
                }
            }
        }

        public virtual void SetOwner<TAbilitySystem>(TAbilitySystem owner) where TAbilitySystem : AbilitySystem
        {
            Owner = owner;
        }

        protected IEnumerator RunGraph(Queue<Node> nodesToExecute)
        {
            while (nodesToExecute.Count > 0)
            {
                var node = nodesToExecute.Dequeue();
                switch (node)
                {
                    case WaitNode waitNode:
                        EnqueueNodes(nodesToExecute, waitNode.GetExecuteNodes());
                        waitNode.Execute(waitedNode => { RunNodes(waitedNode.GetWaitExecuteNodes()); });
                        yield return waitNode;
                        break;
                    case ForLoopNode forLoopNode:
                        EnqueueNodes(nodesToExecute, forLoopNode.GetExecuteNodes());
                        forLoopNode.index = 0;
                        for (var i = 0; i < forLoopNode.LoopCount; i++)
                        {
                            RunNodes(forLoopNode.GetLoopBodyNodes());
                            forLoopNode.index++;
                        }

                        forLoopNode.Execute();
                        yield return forLoopNode;
                        break;
                    case ConditionalNode conditionalNode:
                        EnqueueNodes(nodesToExecute, conditionalNode.GetExecuteNodes());
                        conditionalNode.Execute();
                        yield return conditionalNode;
                        break;
                }
            }
        }

        private void RunNodes(Queue<Node> nodesToRun)
        {
            var enumerator = RunGraph(nodesToRun);
            while (enumerator.MoveNext()) ;
        }

        private void RunNodes<T>(List<T> nodesToRun) where T : Node
        {
            RunNodes(new Queue<Node>(nodesToRun));
        }

        private void EnqueueNodes<T>(Queue<Node> queue, List<T> nodes) where T : Node
        {
            if (queue == null || nodes == null || nodes.Count == 0)
            {
                return;
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                queue.Enqueue(nodes[i]);
            }
        }

        public bool TryActivate()
        {
            return true;
        }
    }
}