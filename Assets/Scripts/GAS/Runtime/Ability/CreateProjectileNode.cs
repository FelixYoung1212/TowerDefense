using DefaultNamespace;
using DefaultNamespace.Ability;
using UnityEngine;

public class CreateProjectileNode : AbilityNode<Unit>
{
    [Input] public ProjectileAsset projectileAsset;

    public override void Execute()
    {
    }
}