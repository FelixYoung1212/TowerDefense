using Assets.HeroEditor4D.Common.Scripts.Enums;
using GameFramework.Fsm;

namespace DefaultNamespace
{
    public class EnemyIdleState : FsmState<Enemy>
    {
        protected override void OnEnter(IFsm<Enemy> fsm)
        {
            fsm.Owner.MovementController.IsMoving = false;
            fsm.Owner.Character.AnimationManager.SetState(CharacterState.Idle);
        }
    }
}