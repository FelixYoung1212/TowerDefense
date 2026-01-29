using System.Collections.Generic;

namespace GAS.Runtime
{
    public interface IAbilitySystem
    {
        void Init<TAbility>(List<AbilityGraph> abilityGraphs) where TAbility : Ability;
        bool TryActivateAbility(string abilityName);
    }
}