using UnityEngine;
using XNode;

[CreateAssetMenu(menuName = "TowerDefense/Abilities/AbilityBaseGraph")]
public class AbilityBaseGraph : NodeGraph
{
    /// <summary>
    /// 技能开始
    /// </summary>
    public virtual void OnAbilityStart()
    {
        
    }

    /// <summary>
    /// 技能结束
    /// </summary>
    public virtual void OnAbilityEnd()
    {
        
    }
}
