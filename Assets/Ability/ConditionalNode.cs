using System.Collections.Generic;
using XNode;

namespace DefaultNamespace.Ability
{
    public abstract class ConditionalNode : Node
    {
        [Output] public ConditionalLink execute;

        public List<ConditionalNode> GetExecuteNodes()
        {
            List<ConditionalNode> executeNodes = new List<ConditionalNode>();
            foreach (var outputPort in Outputs)
            {
                if (outputPort != null && outputPort.fieldName == nameof(execute))
                {
                    var connections = outputPort.GetConnections();
                    foreach (var connectPort in connections)
                    {
                        executeNodes.Add(connectPort.node as ConditionalNode);
                    }

                    break;
                }
            }

            return executeNodes;
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }

    public abstract class LinkableConditionalNode : ConditionalNode
    {
        [Input] public ConditionalLink executed;
    }
}