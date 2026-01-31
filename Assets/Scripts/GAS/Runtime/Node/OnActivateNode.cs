using System;
using System.Collections.Generic;
using System.Linq;
using GraphProcessor;

namespace GAS.Runtime
{
    [Serializable, NodeMenuItem("技能/激活节点")]
    public class OnActivateNode : BaseNode, IConditionalNode
    {
        [Output(name = "Executes")] public ConditionalLink executes;

        public override string name => "技能开始";

        public IEnumerable<ConditionalNode> GetExecutedNodes()
        {
            return GetOutputNodes().Where(n => n is ConditionalNode).Select(n => n as ConditionalNode);
        }
    }
}