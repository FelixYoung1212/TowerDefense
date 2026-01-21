namespace GAS.Runtime
{
    /// <summary>
    /// 等待N秒执行节点
    /// </summary>
    public class WaitSecondsNode : WaitNode
    {
        [Input] public float waitSeconds;

        public override void Execute()
        {
            float waitSec = GetInputValue(nameof(waitSeconds), waitSeconds);
            WaitNodeHelper.Instance.WaitForSeconds(waitSec, OnExecuteCompleted);
        }
    }
}