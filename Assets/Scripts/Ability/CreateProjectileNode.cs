using GAS.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DefaultNamespace
{
    public class CreateProjectileNode : AbilityNode
    {
        [Input] [LabelText("飞行物预设")] public AssetReferenceT<GameObject> prefab;
        [Input] [LabelText("飞行速度")] public float speed;
        [Input] [LabelText("目标")] public Unit target;
        private new UnitAbilitySystemComponent Owner { get; set; }

        public override void Init(IAbilitySystemComponent owner)
        {
            base.Init(owner);
            Owner = base.Owner as UnitAbilitySystemComponent;
        }

        public override void Execute()
        {
            var direction = !target ? Vector3.up : Vector3.Normalize(target.transform.position - Owner.transform.position);
            GameEntry.Entity.ShowEntity<Projectile>(2000, prefab.RuntimeKey as string, "Arrow", arrow =>
            {
                arrow.transform.position = Owner.transform.position + new Vector3(0, 0, -0.1f);
                arrow.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                arrow.Init(speed, direction);
            });
        }
    }
}