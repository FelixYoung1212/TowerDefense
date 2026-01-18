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
            // 计算旋转让Z轴朝向direction
            Quaternion rotation = Quaternion.LookRotation(direction);
            // 但我们需要X轴朝向direction，所以再旋转90度
            rotation *= Quaternion.Euler(90, -90, 0); // 或者 (0, 90, 0) 取决于朝向
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
        }
    }
}