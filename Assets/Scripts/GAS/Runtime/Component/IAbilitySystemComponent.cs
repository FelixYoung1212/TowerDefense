using System.Collections.Generic;

namespace GAS.Runtime
{
    public interface IAbilitySystemComponent<T>
    {
        void Init(List<Ability<IAbilitySystemComponent<T>>> baseAbilities);
    }
}