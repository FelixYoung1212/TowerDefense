using UnityEngine;

namespace DefaultNamespace.Ability
{
    public class DebugNode : LinkableConditionalNode
    {
        [Input] public string debugInfo;

        public override void Execute()
        {
            Debug.Log(GetInputValue(nameof(debugInfo), debugInfo));
        }
    }
}