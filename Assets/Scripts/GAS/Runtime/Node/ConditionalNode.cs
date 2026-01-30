using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GraphProcessor;
using UnityEngine;

namespace GAS.Runtime
{
    [Serializable]
    public abstract class ConditionalNode : BaseNode, IConditionalNode
    {
        [Input(name = "Executed", allowMultiple = true)]
        public ConditionalLink executed;

        public abstract IEnumerable<ConditionalNode> GetExecutedNodes();

        public override FieldInfo[] GetNodeFields()
        {
            var fields = base.GetNodeFields();
            Array.Sort(fields, (f1, f2) => f1.Name == nameof(executed) ? -1 : 1);
            return fields;
        }
    }

    [Serializable]
    public abstract class LinearConditionalNode : ConditionalNode, IConditionalNode
    {
        [Output(name = "Executes")] public ConditionalLink executes;

        public override IEnumerable<ConditionalNode> GetExecutedNodes()
        {
            return outputPorts.FirstOrDefault(n => n.fieldName == nameof(executes))
                .GetEdges().Select(e => e.inputNode as ConditionalNode);
        }
    }

    [Serializable]
    public abstract class WaitableNode : LinearConditionalNode
    {
        [Output(name = "Execute After")] public ConditionalLink executeAfter;

        protected void ProcessFinished()
        {
            onProcessFinished.Invoke(this);
        }

        [HideInInspector] public Action<WaitableNode> onProcessFinished;

        public IEnumerable<ConditionalNode> GetExecuteAfterNodes()
        {
            return outputPorts.FirstOrDefault(n => n.fieldName == nameof(executeAfter))
                .GetEdges().Select(e => e.inputNode as ConditionalNode);
        }
    }
}