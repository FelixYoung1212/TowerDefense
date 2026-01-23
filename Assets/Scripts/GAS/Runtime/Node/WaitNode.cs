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

        public List<ConditionalNode> GetWaitExecuteNodes() => GetConditionalNodes(nameof(waitExecute));

        public virtual void Execute(Action<WaitNode> onWaitExecute)
        {

        }
    }
}