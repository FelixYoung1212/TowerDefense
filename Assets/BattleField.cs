using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class BattleField : MonoBehaviour
    {
        [FormerlySerializedAs("m_EnemySpawnPointManager")] [SerializeField] private EnemySpawnArea m_EnemySpawnArea;
    }
}