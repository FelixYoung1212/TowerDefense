using UnityEngine;

public class EnemySpawnPointManager : MonoBehaviour
{
    [SerializeField] private Transform m_StartPoint;
    [SerializeField] private Transform m_EndPoint;

    /// <summary>
    /// 获取出生点
    /// </summary>
    /// <returns></returns>
    public Vector3 GetSpawnPoint()
    {
        return Vector3.Lerp(m_StartPoint.position, m_EndPoint.position, Random.value);
    }
}