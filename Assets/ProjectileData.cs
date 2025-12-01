using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// 飞行物数据类
    /// </summary>
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "ProjectileData")]
    public class ProjectileData : ScriptableObject
    {
        [Header("飞行物预设")] [SerializeField] private GameObject m_Prefab;
        [Header("飞行物速度")] [SerializeField] private float m_Speed;
    }
}