using System;
using System.Collections;

namespace DefaultNamespace.Ability
{
    public abstract class WaitNode : LinkableConditionalNode
    {
        public void Execute(Action onComplete)
        {
            CoroutineManager.Instance.StartCoroutine(WaitCoroutine(onComplete));
        }

        protected abstract IEnumerator WaitCoroutine(Action onComplete);
    }
}