using UnityEngine;

namespace DefaultNamespace.Ability
{
    public abstract class AbilityNode<T> : LinkableConditionalNode
    {
        /// <summary>
        /// 技能所有者
        /// </summary>
        protected T Owner { get; private set; }

        /// <summary>
        /// 技能节点初始化
        /// </summary>
        /// <param name="owner">技能所有者</param>
        public void Init(T owner)
        {
            Owner = owner;
        }
    }
}