using System.Collections.Generic;
using GameFramework.Entity;
using GAS.Runtime;
using UnityEngine;
using UnityGameFramework.Runtime;
using XNode;

namespace DefaultNamespace
{
    public class GetEnemyNode : Node, IAbilityOwner<UnitAbility>
    {
        [Output] public Unit enemy;

        private IEntityGroup m_EnemyEntityGroup;

        private readonly List<IEntity> m_Enemys = new List<IEntity>();

        public UnitAbility Ability { get; private set; }

        public void SetAbility(UnitAbility ability)
        {
            Ability = ability;
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(enemy))
            {
                if (!Application.isPlaying)
                {
                    return null;
                }

                m_EnemyEntityGroup ??= GameEntry.Entity.GetEntityGroup("Enemy");

                if (m_EnemyEntityGroup == null)
                {
                    return null;
                }

                m_EnemyEntityGroup.GetAllEntities(m_Enemys);
                return ((Entity)m_Enemys[Random.Range(0, m_Enemys.Count)]).Logic;
                // var minDistance = float.MaxValue;
                // Unit closestEnemy = null;
                // foreach (var enemy in m_Enemys)
                // {
                //     var distance = Vector3.Distance(((Entity)enemy).transform.position, Ability.Owner.transform.position);
                //     if (distance < minDistance)
                //     {
                //         minDistance = distance;
                //         closestEnemy = (Unit)((Entity)enemy).Logic;
                //     }
                // }
                //
                // return closestEnemy;
            }

            return null;
        }
    }
}