using System.Collections;
using System.Collections.Generic;
using XNode;

namespace DefaultNamespace.Ability
{
    public class Ability
    {
        private AbilityGraph m_Graph;

        private readonly List<AbilityStartNode> m_StartNodes = new List<AbilityStartNode>();
        private readonly List<OnProjectileHitNode> m_OnProjectileHitNodes = new List<OnProjectileHitNode>();

        public Ability(AbilityGraph graph)
        {
            m_Graph = graph;
            foreach (var node in m_Graph.nodes)
            {
                if (node is AbilityStartNode startNode)
                {
                    m_StartNodes.Add(startNode);
                }
                else if (node is OnProjectileHitNode onProjectileHitNode)
                {
                    m_OnProjectileHitNodes.Add(onProjectileHitNode);
                }
            }
        }

        public void Start()
        {
            if (m_StartNodes.Count == 0)
            {
                return;
            }

            Queue<Node> nodesToExecute = new Queue<Node>();
            for (var i = 0; i < m_StartNodes.Count; i++)
            {
                nodesToExecute.Enqueue(m_StartNodes[i]);
            }

            var enumerator = RunGraph(nodesToExecute);
            while (enumerator.MoveNext()) ;
        }

        public void OnProjectileHit(Unit hitTarget)
        {
            if (m_OnProjectileHitNodes.Count == 0)
            {
                return;
            }

            Queue<Node> nodesToExecute = new Queue<Node>();
            for (var i = 0; i < m_OnProjectileHitNodes.Count; i++)
            {
                nodesToExecute.Enqueue(m_OnProjectileHitNodes[i]);
            }

            var enumerator = RunGraph(nodesToExecute);
            while (enumerator.MoveNext()) ;
        }

        private IEnumerator RunGraph(Queue<Node> nodesToExecute)
        {
            while (nodesToExecute.Count > 0)
            {
                var node = nodesToExecute.Dequeue();
                switch (node)
                {
                    case WaitNode waitNode:
                        waitNode.onExecuteCompleted += (waitedNode) =>
                        {
                            Queue<Node> waitedNodes = new Queue<Node>();
                            var executeNodes = waitNode.GetExecuteNodes();
                            for (int i = 0; i < executeNodes.Count; i++)
                            {
                                waitedNodes.Enqueue(executeNodes[i]);
                            }

                            WaitedRun(waitedNodes);
                            waitNode.onExecuteCompleted = null;
                        };
                        waitNode.Execute();
                        yield return waitNode;
                        break;
                    case ConditionalNode conditionalNode:
                        var executeNodes = conditionalNode.GetExecuteNodes();
                        for (int i = 0; i < executeNodes.Count; i++)
                        {
                            nodesToExecute.Enqueue(executeNodes[i]);
                        }

                        conditionalNode.Execute();
                        yield return conditionalNode;
                        break;
                }
            }
        }

        private void WaitedRun(Queue<Node> nodesToRun)
        {
            var enumerator = RunGraph(nodesToRun);
            while (enumerator.MoveNext()) ;
        }
    }
}