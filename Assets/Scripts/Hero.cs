using GAS.Runtime;

namespace DefaultNamespace
{
    public class Hero : Unit
    {
        public AbilitySystem AbilitySystem { get; private set; }

        private void Awake()
        {
            AbilitySystem = gameObject.AddComponent<AbilitySystem>();
        }
    }
}