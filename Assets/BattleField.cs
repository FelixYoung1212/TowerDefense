using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace DefaultNamespace
{
    public class BattleField : MonoBehaviour
    {
        [SerializeField] private EnemySpawnArea m_EnemySpawnArea;
        [SerializeField] private RectTransform m_HeroSpawnPoint;

        private void OnEnable()
        {
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
        }

        private void OnDisable()
        {
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
        }

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                GameEntry.Entity.ShowEntity<Enemy>(i + 1, "Assets/AddressableResources/Enemys/Enemy1.prefab", "Enemy");
            }

            GameEntry.Entity.ShowEntity<Hero>(1000, "Assets/AddressableResources/Heros/Hero1.prefab", "Hero");
        }

        private void OnShowEntitySuccess(object sender, GameEventArgs eventArgs)
        {
            var showEntitySuccessEventArgs = (ShowEntitySuccessEventArgs)eventArgs;
            var entity = showEntitySuccessEventArgs.Entity;
            if (entity.EntityGroup.Name == "Hero")
            {
                entity.transform.position = m_HeroSpawnPoint.position;
                entity.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else if (entity.EntityGroup.Name == "Enemy")
            {
                entity.transform.position = m_EnemySpawnArea.GetRandomSpawnPoint();
                entity.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
        }
    }
}