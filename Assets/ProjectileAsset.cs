using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// 飞行物资源
    /// </summary>
    [CreateAssetMenu(fileName = "ProjectileAsset", menuName = "ProjectileAsset")]
    public class ProjectileAsset : ScriptableObject
    {
        [LabelText("飞行物预设")] [SerializeField] private GameObject m_Prefab;
        [LabelText("伤害特效")] [SerializeField] private GameObject m_DamageEffect;
        [LabelText("飞行物速度")] [SerializeField] private float m_Speed;
        [LabelText("飞行物类型")] [SerializeField] private ProjectileType m_Type;

        public ProjectileType Type => m_Type;
        public GameObject Prefab => m_Prefab;
        public float Speed => m_Speed;
    }
}