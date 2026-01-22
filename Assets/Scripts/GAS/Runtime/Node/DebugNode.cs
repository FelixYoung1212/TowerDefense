using UnityEngine;
using XNode;

namespace GAS.Runtime
{
    /// <summary>
    /// 调试节点输出调试信息
    /// </summary>
    public class DebugNode : LinkableConditionalNode
    {
        public LogType logType;
        [Input] public string debugInfo;

        public override void Execute()
        {
            switch (logType)
            {
                case LogType.Info:
                    Debug.Log(GetInputValue(nameof(debugInfo), debugInfo));
                    break;
                case LogType.Warning:
                    Debug.LogWarning(GetInputValue(nameof(debugInfo), debugInfo));
                    break;
                case LogType.Error:
                    Debug.LogError(GetInputValue(nameof(debugInfo), debugInfo));
                    break;
            }
        }
    }

    public enum LogType
    {
        Info,
        Warning,
        Error,
    }
}