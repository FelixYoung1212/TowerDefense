using System;
using cfg;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityGameFramework.Runtime;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    [Header("飞行速度")] [SerializeField] private float m_Speed;

    private Vector3 m_Direction;

    private BattleField m_BattleFie;

    private void Update()
    {
        transform.position += m_Direction * (m_Speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameEntry.GetComponent<EntityComponent>().ShowEntity<ArrowEntityLogic>(1,"Assets/AddressableResources/Arrow.prefab","Enemy");
            GameEntry.GetComponent<EntityComponent>().ShowEntity<ArrowEntityLogic>(2,"Assets/AddressableResources/Arrow.prefab","Enemy");
            // GameEntry.GetComponent<EntityComponent>().ShowEntity<ArrowEntityLogic>(3,"Assets/AddressableResources/Arrow1.prefab","Enemy");
            // GameEntry.GetComponent<EntityComponent>().ShowEntity<ArrowEntityLogic>(1, "Arrow.prefab", "Enemy");
            // GameEntry.GetComponent<EntityComponent>().ShowEntity<ArrowEntityLogic>(2, "Arrow.prefab", "Enemy");
            // GameEntry.GetComponent<EntityComponent>().ShowEntity<ArrowEntityLogic>(3, "Arrow1.prefab", "Enemy");
            GameEntry.GetComponent<DataTableComponent>().CreateDataTable(typeof(Item)).ReadData("Assets/AddressableResources/DataTables/item_tbitem.bytes");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            GameEntry.GetComponent<EntityComponent>().HideEntity(1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GameEntry.GetComponent<SceneComponent>().LoadScene("Assets/Scenes/Test.scene");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GameEntry.GetComponent<SceneComponent>().UnloadScene("Assets/Scenes/Test.scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }
}