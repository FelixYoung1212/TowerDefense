using cfg;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : EntityLogic
    {
        [SerializeField] private Rigidbody2D m_Rigidbody2D;
        [Header("飞行速度")] [SerializeField] private float m_Speed;

        private Vector3 m_Direction;

        private BattleField m_BattleFie;

        private void Update()
        {
            transform.position += m_Direction * (m_Speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
        }
    }
}