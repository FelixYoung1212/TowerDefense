using System.Collections.Generic;

namespace GAS.Runtime
{
    public interface IAbilitySystem
    {
        void Init<TAbility, TAbilityGraph>(List<TAbilityGraph> abilityGraphs)
            where TAbility : Ability where TAbilityGraph : AbilityGraph;

        bool TryActivateAbility(string abilityName);
    }
}