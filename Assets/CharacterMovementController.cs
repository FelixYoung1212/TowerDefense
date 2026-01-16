using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CharacterMovementController : MonoBehaviour
    {
        [SerializeField] private float m_MovementSpeed = 0.1f;

        private bool m_IsMoving;

        public bool IsMoving
        {
            get => m_IsMoving;
            set => m_IsMoving = value;
        }

        /// <summary>
        /// 角色移动速度
        /// </summary>
        public float MovementSpeed
        {
            get => m_MovementSpeed;
            set => m_MovementSpeed = value;
        }

        private void Update()
        {
            if (m_IsMoving)
            {
                transform.Translate(Vector2.down * (m_MovementSpeed * Time.deltaTime));
            }
        }
    }
}