using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAS.Runtime
{
    /// <summary>
    /// 能力系统类
    /// </summary>
    public class AbilitySystem : MonoBehaviour, IAbilitySystem
    {
        private readonly Dictionary<string, Ability> m_Abilities = new Dictionary<string, Ability>();
        protected IReadOnlyDictionary<string, Ability> Abilities => m_Abilities;
        private bool m_Initialized;

        public virtual void Init<TAbility, TAbilityGraph>(List<TAbilityGraph> abilityGraphs)
            where TAbility : Ability where TAbilityGraph : AbilityGraph
        {
            if (abilityGraphs == null || abilityGraphs.Count == 0) return;
            foreach (var abilityGraph in abilityGraphs)
            {
                if (Activator.CreateInstance(typeof(TAbility), abilityGraph, this) is TAbility ability)
                {
                    if (!m_Abilities.TryAdd(ability.Name, ability))
                    {
                        Debug.LogError($"Ability with name {ability.Name} already exists in {GetType().Name}.");
                    }
                }
            }

            m_Initialized = true;
        }

        public bool TryActivateAbility(string abilityName)
        {
            if (!m_Abilities.TryGetValue(abilityName, out var ability))
            {
                return false;
            }

            return ability.TryActivate();
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