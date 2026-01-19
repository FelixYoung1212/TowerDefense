using UnityEngine;

namespace DefaultNamespace
{
    public class BattleField : MonoBehaviour
    {
        [SerializeField] private EnemySpawnArea m_EnemySpawnArea;
        [SerializeField] private RectTransform m_HeroSpawnPoint;
        [SerializeField] private AbilityGraph m_AbilityGraph;

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                GameEntry.Entity.ShowEntity<Enemy>(i + 1, "Assets/AddressableResources/Enemys/Enemy1.prefab", "Enemy", enemy =>
                {
                    enemy.transform.position = m_EnemySpawnArea.GetRandomSpawnPoint();
                    enemy.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                });
            }

            GameEntry.Entity.ShowEntity<Hero>(1000, "Assets/AddressableResources/Heros/Hero1.prefab", "Hero", hero =>
            {
                hero.transform.position = m_HeroSpawnPoint.position;
                hero.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            });
            var ability = new Ability.Ability(m_AbilityGraph);
            ability.Start();
        }
    }
}