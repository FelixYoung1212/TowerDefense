using System;

namespace GAS.Runtime
{
    /// <summary>
    /// 等待N秒执行节点
    /// </summary>
    public class WaitSecondsNode : WaitNode
    {
        [Input(connectionType = ConnectionType.Override)] public float waitSeconds;

        public override void Execute()
        {
            
        }

        public override void Execute(Action<WaitNode> onWaitExecute)
        {
            float waitSec = GetInputValue(nameof(waitSeconds), waitSeconds);
            WaitNodeHelper.Instance.WaitForSeconds(waitSec, () => onWaitExecute(this));
        }
    }
}