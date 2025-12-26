using System.Collections.Generic;

namespace DefaultNamespace.Ability
{
    public class Ability
    {
        private AbilityGraph m_Graph;

        private AbilityStartNode m_StartNode;

        private OnProjectileHitNode m_OnProjectileHitNode;

        public Ability(AbilityGraph graph)
        {
            m_Graph = graph;
            foreach (var node in m_Graph.nodes)
            {
                if (node is AbilityStartNode startNode)
                {
                    m_StartNode = startNode;
                }

                if (node is OnProjectileHitNode onProjectileHitNode)
                {
                    m_OnProjectileHitNode = onProjectileHitNode;
                }
            }
        }

        public void AbilityStart()
        {
            if (m_StartNode == null)
            {
                return;
            }

            var executeNodes = m_StartNode.GetExecuteNodes();
            if (executeNodes.Count == 0)
            {
                return;
            }

            var nodesToExecute = new Queue<ConditionalNode>();
            foreach (var conditionalNode in executeNodes)
            {
                nodesToExecute.Enqueue(conditionalNode);
            }
        }

        public void OnProjectileHit()
        {
            if (m_OnProjectileHitNode == null)
            {
                return;
            }

            m_OnProjectileHitNode.GetExecuteNodes();
        }
    }
}