using cfg;
using UnityEngine;

namespace DefaultNamespace
{
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
                GameEntry.DataTable.CreateDataTable(typeof(Item)).ReadData("Assets/AddressableResources/DataTables/item_tbitem.bytes");
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                GameEntry.Entity.HideEntity(1);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                GameEntry.Scene.LoadScene("Assets/Scenes/Test.scene");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                GameEntry.Scene.UnloadScene("Assets/Scenes/Test.scene");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
        }
    }
}