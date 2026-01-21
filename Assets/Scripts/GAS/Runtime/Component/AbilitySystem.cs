using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAS.Runtime
{
    public abstract class AbilitySystem<TAbilitySystem, TAbility, TAbilityGraph> : MonoBehaviour
        where TAbilitySystem : AbilitySystem<TAbilitySystem, TAbility, TAbilityGraph>
        where TAbility : Ability<TAbilitySystem, TAbility, TAbilityGraph>
        where TAbilityGraph : AbilityGraph
    {
        private readonly List<TAbility> m_Abilities = new List<TAbility>();
        protected IReadOnlyList<TAbility> Abilities => m_Abilities;
        private bool m_Initialized;

        public virtual void Init(List<TAbilityGraph> abilityGraphs)
        {
            if (abilityGraphs == null || abilityGraphs.Count == 0) return;
            foreach (var abilityGraph in abilityGraphs)
            {
                if (Activator.CreateInstance(typeof(TAbility), abilityGraph, this) is TAbility ability)
                {
                    m_Abilities.Add(ability);
                }
            }

            m_Initialized = true;
        }

        public void Clear()
        {
            if (!m_Initialized)
            {
                return;
            }

            m_Abilities.Clear();
            m_Initialized = false;
        }
    }
}