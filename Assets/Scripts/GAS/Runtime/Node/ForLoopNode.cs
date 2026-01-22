using System.Collections.Generic;

namespace GAS.Runtime
{
    public class ForLoopNode : LinkableConditionalNode
    {
        [Input] public int loopCount;
        [Output] public ConditionalLink loopBody;
        [Output] public int index;

        public List<ConditionalNode> GetLoopBodyNodes() => GetConditionalNodes(nameof(loopBody));

        public int LoopCount => GetInputValue(nameof(loopCount), loopCount);

        public override void Execute()
        {
            index++;
        }
    }
}