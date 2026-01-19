using UnityEngine;

namespace GAS.Runtime
{
    /// <summary>
    /// 调试节点输出调试信息
    /// </summary>
    public class DebugNode : LinkableConditionalNode
    {
        [Input] public string debugInfo;

        public override void Execute()
        {
            Debug.Log(GetInputValue(nameof(debugInfo), debugInfo));
        }
    }
}