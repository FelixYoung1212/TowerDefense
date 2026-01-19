using Assets.HeroEditor4D.Common.Scripts.Enums;
using GameFramework.Fsm;

namespace DefaultNamespace
{
    public class EnemyMoveState : FsmState<Enemy>
    {
        protected override void OnEnter(IFsm<Enemy> fsm)
        {
            fsm.Owner.MovementController.IsMoving = true;
            fsm.Owner.Character.AnimationManager.SetState(CharacterState.Walk);
        }
    }
}