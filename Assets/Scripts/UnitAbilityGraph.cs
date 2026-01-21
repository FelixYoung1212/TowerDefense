using GAS.Runtime;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "GAS/Unit Ability Graph", fileName = "New Unit Ability Graph")]
    public class UnitAbilityGraph : AbilityGraph
    {
        [SerializeField] private int m_ID;
        public int ID => m_ID;
    }
}