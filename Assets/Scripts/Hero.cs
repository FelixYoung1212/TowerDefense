namespace DefaultNamespace
{
    public class Hero : Unit
    {
        public UnitAbilitySystem AbilitySystem { get; private set; }

        private void Awake()
        {
            AbilitySystem = gameObject.AddComponent<UnitAbilitySystem>();
        }
    }
}