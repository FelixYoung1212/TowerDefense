using System.Collections.Generic;
using GAS.Runtime;
using XNode;

namespace DefaultNamespace
{
    public class Ability : Ability<UnitAbilitySystemComponent>
    {
        private readonly List<AbilityStartNode> m_StartNodes = new List<AbilityStartNode>();
        private readonly List<OnProjectileHitNode> m_OnProjectileHitNodes = new List<OnProjectileHitNode>();
        private readonly List<AbilityNode> m_AbilityNodes = new List<AbilityNode>();

        public Ability(AbilityGraph graph) : base(graph)
        {
            InitNodes();
        }

        public Ability(AbilityGraph graph, UnitAbilitySystemComponent owner) : base(graph, owner)
        {
            InitNodes();
            InitAbilityNodes(owner);
        }

        public override void SetOwner(UnitAbilitySystemComponent owner)
        {
            base.SetOwner(owner);
            InitAbilityNodes(owner);
        }

        private void InitAbilityNodes(UnitAbilitySystemComponent owner)
        {
            foreach (var abilityNode in m_AbilityNodes)
            {
                abilityNode.Init(owner);
            }
        }

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
                else if (node is AbilityNode abilityNode)
                {
                    m_AbilityNodes.Add(abilityNode);
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