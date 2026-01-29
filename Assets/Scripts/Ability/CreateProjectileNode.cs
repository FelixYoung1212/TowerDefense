using System.Collections.Generic;
using GameFramework.Entity;
using GAS.Runtime;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityGameFramework.Runtime;

namespace DefaultNamespace
{
    public class CreateProjectileNode : LinkableConditionalNode, IAbilityOwner
    {
        [Input] public AssetReferenceT<GameObject> prefab;
        [Input] public float speed;
        private int m_ID = 2000;
        private IEntityGroup m_EnemyEntityGroup;
        private readonly List<IEntity> m_Enemys = new List<IEntity>();

        public Ability Ability { get; private set; }

        public void SetAbility(Ability ability)
        {
            Ability = ability;
        }

        public override void Execute()
        {
            m_EnemyEntityGroup ??= GameEntry.Entity.GetEntityGroup("Enemy");

            EntityLogic target = null;
            if (m_EnemyEntityGroup != null)
            {
                m_EnemyEntityGroup.GetAllEntities(m_Enemys);
                target = ((Entity)m_Enemys[Random.Range(0, m_Enemys.Count)]).Logic;
            }

            var direction = !target
                ? Vector3.up
                : Vector3.Normalize(target.transform.position - Ability.Owner.transform.position);
            GameEntry.Entity.ShowEntity<Projectile>(m_ID++, prefab.RuntimeKey as string, "Arrow", arrow =>
            {
                arrow.transform.position = Ability.Owner.transform.position + new Vector3(0, 0, -0.1f);
                arrow.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                arrow.Init(speed, direction);
            });
        }
    }
}