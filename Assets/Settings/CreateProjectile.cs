using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DefaultNamespace;

[TaskCategory("攻击")]
[TaskName("创建发射物")]
public class CreateProjectile : Action
{
    [SerializeField] private ProjectileData m_ProjectileData;
    private Unit m_Unit;

    public override void OnStart()
    {
        m_Unit = GetComponent<Unit>();
    }

    public override TaskStatus OnUpdate()
    {
        if (m_ProjectileData == null)
        {
            Debug.LogError("ProjectileData is not set.");
            return TaskStatus.Failure;
        }

        if (m_Unit == null)
        {
            Debug.LogError("Unit component is not found.");
            return TaskStatus.Failure;
        }

        return TaskStatus.Success;
    }
}