namespace GAS.Runtime
{
    public interface IAbilityOwner
    {
        /// <summary>
        /// 技能所有者
        /// </summary>
        public Ability Ability { get; }

        /// <summary>
        /// 技能所有者初始化
        /// </summary>
        /// <param name="ability">技能所有者</param>
        public void SetAbility(Ability ability);
    }
}