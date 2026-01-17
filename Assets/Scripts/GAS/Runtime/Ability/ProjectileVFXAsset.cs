using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GAS.Runtime.Ability
{
    /// <summary>
    /// 飞行物特效资源
    /// </summary>
    [CreateAssetMenu(fileName = "ProjectileVFXAsset", menuName = "ProjectileVFXAsset")]
    public class ProjectileVFXAsset : ScriptableObject
    {
        [LabelText("飞行物预设")] [SerializeField] private AssetReferenceT<GameObject> m_Prefab;
        public string PrefabRuntimeKey => m_Prefab.RuntimeKey as string;
        [SerializeField] [LabelText("飞行速度")] private float m_Speed;
        public float Speed => m_Speed;
    }
}