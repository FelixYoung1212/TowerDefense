using System;

namespace DefaultNamespace.Ability
{
    public class WaitSecondsNode : LinkableConditionalNode, IUpdate
    {
        [Input] public float waitSeconds;

        public void Execute(Action onComplete)
        {
        }

        public void OnUpdate(float deltaTime)
        {
        }
    }
}