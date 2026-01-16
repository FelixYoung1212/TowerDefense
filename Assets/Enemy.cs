using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using GameFramework.Fsm;
using UnityEngine;

namespace DefaultNamespace
{
    public class Enemy : Unit
    {
        private Character4D m_Character;
        public Character4D Character => m_Character;
        private CharacterMovementController m_MovementController;
        public CharacterMovementController MovementController => m_MovementController;
        private IFsm<Enemy> m_Fsm;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_Character = GetComponent<Character4D>();
            m_Character.SetDirection(Vector2.down);
            m_MovementController = gameObject.AddComponent<CharacterMovementController>();
            m_Fsm = GameEntry.Fsm.CreateFsm(gameObject.name + Entity.Id, this, new EnemyIdleState(), new EnemyMoveState());
            m_Fsm.Start<EnemyMoveState>();
        }
    }
}