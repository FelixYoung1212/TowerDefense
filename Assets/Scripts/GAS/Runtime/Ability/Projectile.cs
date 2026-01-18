using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GAS.Runtime.Ability
{
    /// <summary>
    /// 飞行物特效类
    /// </summary>
    public class Projectile : EntityLogic
    {
        private float m_Speed;
        private Vector3 m_Direction;

        public void Init(float speed, Vector3 direction)
        {
            m_Speed = speed;
            m_Direction = direction;
            Quaternion rotation = Quaternion.LookRotation(direction);
            rotation *= Quaternion.Euler(90, -90, 0);
            transform.rotation = rotation;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            gameObject.transform.Translate(m_Direction * (m_Speed * elapseSeconds), Space.World);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                GameEntry.Entity.HideEntity(Entity);
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                GameEntry.Entity.HideEntity(Entity);
                GameEntry.Entity.HideEntity(other.GetComponent<Entity>());
            }
        }
    }
}