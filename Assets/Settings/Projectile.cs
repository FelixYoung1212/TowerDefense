using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    [Header("飞行速度")] [SerializeField] private float m_Speed;

    private Vector3 m_Direction;

    private BattleField m_BattleField;

    
    private void Update()
    {
        transform.position += m_Direction * (m_Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }
}