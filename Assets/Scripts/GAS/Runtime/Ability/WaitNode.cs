using System;

namespace GAS.Runtime
{
    /// <summary>
    /// 等待执行节点抽象类
    /// </summary>
    public abstract class WaitNode : LinkableConditionalNode
    {
        public Action<WaitNode> onExecuteCompleted;

        protected void OnExecuteCompleted()
        {
            onExecuteCompleted?.Invoke(this);
        }
    }
}