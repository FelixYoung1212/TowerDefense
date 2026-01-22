using System;
using System.Collections.Generic;

namespace GAS.Runtime
{
    /// <summary>
    /// 等待执行节点抽象类
    /// </summary>
    public abstract class WaitNode : LinkableConditionalNode
    {
        [Output] public ConditionalLink waitExecute;
        public Action<WaitNode> onExecuteCompleted;

        public List<ConditionalNode> GetWaitExecuteNodes() => GetConditionalNodes(nameof(waitExecute));

        protected void OnExecuteCompleted()
        {
            onExecuteCompleted?.Invoke(this);
        }
    }
}