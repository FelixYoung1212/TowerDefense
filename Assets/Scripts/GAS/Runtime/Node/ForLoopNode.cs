using System;
using System.Collections.Generic;
using XNode;

namespace GAS.Runtime
{
    public class ForLoopNode : LinkableConditionalNode
    {
        [Input(connectionType = ConnectionType.Override)] public int loopCount;
        [Output] public ConditionalLink loopBody;
        [Output] public int index;

        public List<ConditionalNode> GetLoopBodyNodes() => GetConditionalNodes(nameof(loopBody));

        public int LoopCount => GetInputValue(nameof(loopCount), loopCount);

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(index))
            {
                return index;
            }

            return null;
        }

        public override void Execute()
        {
        }
    }
}