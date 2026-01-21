using System.Collections.Generic;
using GAS.Runtime;

namespace DefaultNamespace
{
    public class UnitAbilitySystem : AbilitySystem<UnitAbilitySystem, UnitAbility, UnitAbilityGraph>
    {
        private readonly Dictionary<int, UnitAbility> m_Abilities = new Dictionary<int, UnitAbility>();

        public override void Init(List<UnitAbilityGraph> abilityGraphs)
        {
            base.Init(abilityGraphs);
            foreach (var unitAbility in Abilities)
            {
                m_Abilities.Add(unitAbility.ID, unitAbility);
            }
        }

        public bool TryGetAbility(int abilityID, out UnitAbility ability)
        {
            return m_Abilities.TryGetValue(abilityID, out ability);
        }
    }
}