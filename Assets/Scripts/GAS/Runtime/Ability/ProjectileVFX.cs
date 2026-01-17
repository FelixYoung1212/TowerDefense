using UnityEngine;
using UnityGameFramework.Runtime;

namespace GAS.Runtime.Ability
{
    /// <summary>
    /// 飞行物特效类
    /// </summary>
    public class ProjectileVFX : EntityLogic
    {
        private float m_Speed;
        private Vector3 m_Direction;

        public void Init(float speed, Vector3 direction)
        {
            m_Speed = speed;
            m_Direction = direction;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            gameObject.transform.transform.Translate(m_Direction * (m_Speed * elapseSeconds));
        }
    }
}