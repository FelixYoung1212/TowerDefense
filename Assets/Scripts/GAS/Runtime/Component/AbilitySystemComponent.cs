using System.Collections.Generic;
using UnityEngine;

namespace GAS.Runtime
{
    public class AbilitySystemComponent<T> : MonoBehaviour, IAbilitySystemComponent<T> where T : IAbilitySystemComponent<T>
    {
        private readonly List<Ability<IAbilitySystemComponent<T>>> m_Abilities = new List<Ability<IAbilitySystemComponent<T>>>();

        public void Init(List<Ability<IAbilitySystemComponent<T>>> baseAbilities)
        {
            if (baseAbilities != null && baseAbilities.Count > 0)
            {
                m_Abilities.AddRange(baseAbilities);
            }
        }
    }
}