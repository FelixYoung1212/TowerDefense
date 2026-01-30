using System.Collections.Generic;

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
            InitNodes();
        }

        protected Ability(AbilityGraph graph, AbilitySystem owner)
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
                if (node is OnActivateNode onActivateNode)
                {
                    m_OnActivateNodes.Add(onActivateNode);
                }

                if (node is IAbilityOwner abilityOwner)
                {
                    abilityOwner.SetAbility(this);
                }
            }
        }

        public virtual void SetOwner<TAbilitySystem>(TAbilitySystem owner) where TAbilitySystem : AbilitySystem
        {
            Owner = owner;
        }

        public void OnActivate()
        {
            if (m_OnActivateNodes.Count == 0)
            {
                return;
            }
        }

        public bool TryActivate()
        {
            OnActivate();
            return true;
        }
    }
}