using System.Collections;
using System.Collections.Generic;
using GAS.Runtime;
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
            StartCoroutine(CreateEnemies());
        }

        private IEnumerator CreateEnemies()
        {
            yield return new WaitForSeconds(1.0f);
            for (int i = 0; i < 10; i++)
            {
                GameEntry.Entity.ShowEntity<Enemy>(i + 1, "Assets/AddressableResources/Enemys/Enemy1.prefab", "Enemy",
                    enemy =>
                    {
                        enemy.transform.position = m_EnemySpawnArea.GetRandomSpawnPoint();
                        enemy.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    });
            }

            GameEntry.Entity.ShowEntity<Hero>(1000, "Assets/AddressableResources/Heros/Hero1.prefab", "Hero", hero =>
            {
                hero.transform.position = m_HeroSpawnPoint.position;
                hero.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                hero.AbilitySystem.Init<Ability>(new List<AbilityGraph> { m_AbilityGraph });
                hero.AbilitySystem.TryActivateAbility("Ability1");
            });
        }
    }
}