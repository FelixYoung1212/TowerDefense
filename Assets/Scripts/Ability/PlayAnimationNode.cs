using GAS.Runtime;
using GraphProcessor;

namespace DefaultNamespace
{
    public class PlayAnimationNode : LinearConditionalNode
    {
        [Input] public string animationName;
    }
}