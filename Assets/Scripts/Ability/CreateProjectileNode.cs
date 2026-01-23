using GAS.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DefaultNamespace
{
    public class CreateProjectileNode : LinkableConditionalNode, IAbilityOwner<UnitAbility>
    {
        [Input] [LabelText("飞行物预设")] public AssetReferenceT<GameObject> prefab;
        [Input] [LabelText("飞行速度")] public float speed;
        [Input] [LabelText("目标")] public Unit target;
        private int m_ID = 2000;

        public UnitAbility Ability { get; private set; }

        public void SetAbility(UnitAbility ability)
        {
            Ability = ability;
        }

        public override void Execute()
        {
            var targetUnit = GetInputValue(nameof(target), target);
            var direction = !targetUnit ? Vector3.up : Vector3.Normalize(targetUnit.transform.position - Ability.Owner.transform.position);
            GameEntry.Entity.ShowEntity<Projectile>(m_ID++, prefab.RuntimeKey as string, "Arrow", arrow =>
            {
                arrow.transform.position = Ability.Owner.transform.position + new Vector3(0, 0, -0.1f);
                arrow.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                arrow.Init(speed, direction);
            });
        }
    }
}