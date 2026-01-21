using System.Collections.Generic;

namespace GAS.Runtime
{
    public class LoopNode : LinkableConditionalNode
    {
        [Input] public int loopCount;
        [Output] public ConditionalLink loopBody;

        public List<ConditionalNode> GetLoopBodyNodes() => GetConditionalNodes(nameof(loopBody));

        public override void Execute()
        {
        }
    }
}