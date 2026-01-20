namespace GAS.Runtime
{
    /// <summary>
    /// 能力节点
    /// </summary>
    public abstract class AbilityNode : LinkableConditionalNode
    {
        /// <summary>
        /// 技能所有者
        /// </summary>
        protected IAbilitySystemComponent Owner { get; private set; }

        /// <summary>
        /// 技能节点初始化
        /// </summary>
        /// <param name="owner">技能所有者</param>
        public virtual void Init(IAbilitySystemComponent owner)
        {
            Owner = owner;
        }
    }
}