using System;

namespace DefaultNamespace.Ability
{
    public abstract class WaitNode : LinkableConditionalNode
    {
        public Action<WaitNode> onExecuteCompleted;

        protected void OnExecuteCompleted()
        {
            onExecuteCompleted?.Invoke(this);
        }
    }
}