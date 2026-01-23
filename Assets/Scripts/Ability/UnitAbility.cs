using System.Collections.Generic;
using GAS.Runtime;
using XNode;

namespace DefaultNamespace
{
    public class UnitAbility : Ability<UnitAbilitySystem, UnitAbility, UnitAbilityGraph>
    {
        private readonly List<AbilityStartNode> m_StartNodes = new List<AbilityStartNode>();
        private readonly List<OnProjectileHitNode> m_OnProjectileHitNodes = new List<OnProjectileHitNode>();

        public UnitAbility(UnitAbilityGraph graph) : base(graph)
        {
            InitNodes();
        }

        public UnitAbility(UnitAbilityGraph graph, UnitAbilitySystem owner) : base(graph, owner)
        {
            InitNodes();
        }

        public int ID => Graph.ID;

        private void InitNodes()
        {
            foreach (var node in Graph.nodes)
            {
                if (node is AbilityStartNode startNode)
                {
                    m_StartNodes.Add(startNode);
                }
                else if (node is OnProjectileHitNode onProjectileHitNode)
                {
                    m_OnProjectileHitNodes.Add(onProjectileHitNode);
                }

                if (node is IAbilityOwner<UnitAbility> abilityOwnerNode)
                {
                    abilityOwnerNode.SetAbility(this);
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
    }
}