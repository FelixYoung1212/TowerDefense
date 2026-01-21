using System.Collections.Generic;
using XNode;

namespace GAS.Runtime
{
    public abstract class ConditionalNode : Node
    {
        [Output] public ConditionalLink execute;

        protected List<ConditionalNode> GetConditionalNodes(string fieldName)
        {
            List<ConditionalNode> conditionalNodes = new List<ConditionalNode>();
            foreach (var outputPort in Outputs)
            {
                if (outputPort != null && outputPort.fieldName == fieldName)
                {
                    var connections = outputPort.GetConnections();
                    foreach (var connectPort in connections)
                    {
                        conditionalNodes.Add(connectPort.node as ConditionalNode);
                    }

                    break;
                }
            }

            return conditionalNodes;
        }

        public List<ConditionalNode> GetExecuteNodes() => GetConditionalNodes(nameof(execute));

        public override object GetValue(NodePort port)
        {
            return null;
        }

        public virtual void Execute()
        {
        }
    }

    public abstract class LinkableConditionalNode : ConditionalNode
    {
        [Input] public ConditionalLink executed;
    }
}