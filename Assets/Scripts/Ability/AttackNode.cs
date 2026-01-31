using System;
using GAS.Runtime;
using GraphProcessor;

namespace DefaultNamespace
{
    [Serializable, NodeMenuItem("技能/攻击")]
    public class AttackNode : LinearConditionalNode
    {
        [Input("Owner")] public AbilitySystem owner;
        private Hero m_Hero;

        protected override void Process()
        {
            m_Hero = owner.GetComponent<Hero>();

            if (m_Hero == null)
            {
                return;
            }

            m_Hero.Shoot();
        }
    }
}