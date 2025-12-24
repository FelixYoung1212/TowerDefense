using System.Collections.Generic;

namespace DefaultNamespace.Ability
{
    public class Ability
    {
        private AbilityGraph m_Graph;

        private AbilityStartNode m_StartNode;

        private OnProjectileHitNode m_OnProjectileHitNode;

        private List<IUpdate> m_UpdateNodes = new List<IUpdate>();

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

        public void Update(float deltaTime)
        {
            for (var i = m_UpdateNodes.Count - 1; i >= 0; i--)
            {
                m_UpdateNodes[i].OnUpdate(deltaTime);
            }
        }

        public void AbilityStart()
        {
            if (m_StartNode == null)
            {
                return;
            }

            m_StartNode.GetExecuteNodes();
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