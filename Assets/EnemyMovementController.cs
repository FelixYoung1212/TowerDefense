using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private float m_MovementSpeed = 2.0f;

        private void Update()
        {
            transform.Translate(Vector2.left * (m_MovementSpeed * Time.deltaTime));
        }
    }
}