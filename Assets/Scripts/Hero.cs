using Assets.HeroEditor.Common.Scripts.CharacterScripts;
using GAS.Runtime;

namespace DefaultNamespace
{
    public class Hero : Unit
    {
        public AbilitySystem AbilitySystem { get; private set; }
        public Character Character { get; private set; }

        private void Awake()
        {
            AbilitySystem = gameObject.AddComponent<AbilitySystem>();
            Character = gameObject.GetComponent<Character>();
        }

        public void Shoot()
        {
            Character.SetState(CharacterState.Ready);
            StartCoroutine(Character.Shoot());
        }
    }
}