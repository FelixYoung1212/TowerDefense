using DefaultNamespace.Ability;
using GAS.Runtime.Ability;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CreateProjectileNode : AbilityNode<Unit>
{
    [Input] [LabelText("飞行物预设")] public AssetReferenceT<GameObject> prefab;
    [Input] [LabelText("飞行速度")] public float speed;
    [Input] [LabelText("目标")] public Unit target;

    public override void Execute()
    {
        var direction = !target ? Vector3.up : Vector3.Normalize(target.transform.position - Owner.transform.position);
        GameEntry.Entity.ShowEntity<Projectile>(2000, prefab.RuntimeKey as string, "Arrow", vfx =>
        {
            vfx.transform.position = new Vector3(0, 0, 1);
            vfx.Init(speed, direction);
        });
    }
}