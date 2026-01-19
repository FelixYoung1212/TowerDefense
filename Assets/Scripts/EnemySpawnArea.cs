using UnityEngine;

public class EnemySpawnArea : MonoBehaviour
{
    [SerializeField] private RectTransform m_SpawnArea;

    /// <summary>
    /// 获取随机出生点
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRandomSpawnPoint() => GetRandomWorldPointInRectTransform(m_SpawnArea);

    /// <summary>
    /// 在RectTransform里面获取一个随机的本地坐标
    /// </summary>
    /// <param name="rectTransform"></param>
    /// <returns></returns>
    private Vector2 GetRandomPointInRectTransform(RectTransform rectTransform)
    {
        if (rectTransform == null)
        {
            return Vector2.zero;
        }

        var rect = rectTransform.rect;

        // 在矩形范围内随机一个本地坐标点
        var randomX = Random.Range(rect.xMin, rect.xMax);
        var randomY = Random.Range(rect.yMin, rect.yMax);

        return new Vector2(randomX, randomY);
    }

    /// <summary>
    /// 在RectTransform里面获取一个随机的世界坐标
    /// </summary>
    /// <param name="rectTransform"></param>
    /// <returns></returns>
    private Vector3 GetRandomWorldPointInRectTransform(RectTransform rectTransform)
    {
        if (rectTransform == null)
        {
            return Vector3.zero;
        }

        var localPoint = GetRandomPointInRectTransform(rectTransform);
        return rectTransform.TransformPoint(localPoint);
    }
}