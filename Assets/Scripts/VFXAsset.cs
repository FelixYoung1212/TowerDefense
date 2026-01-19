using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// 特效资源
    /// </summary>
    [CreateAssetMenu(fileName = "VFXAsset", menuName = "VFXAsset")]
    public class VFXAsset : ScriptableObject
    {
        [LabelText("特效预设")] [SerializeField] private GameObject m_Prefab;
        public GameObject Prefab => m_Prefab;
    }
}