using System;

namespace DefaultNamespace
{
    public class Hero : Unit
    {
        public UnitAbilitySystemComponent AbilitySystem { get; private set; }

        private void Awake()
        {
            AbilitySystem = gameObject.AddComponent<UnitAbilitySystemComponent>();
        }
    }
}