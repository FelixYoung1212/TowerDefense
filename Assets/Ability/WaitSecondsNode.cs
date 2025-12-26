using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Ability
{
    public class WaitSecondsNode : WaitNode
    {
        [Input] public float waitSeconds;

        protected override IEnumerator WaitCoroutine(Action onComplete)
        {
            yield return new WaitForSeconds(waitSeconds);
            onComplete?.Invoke();
        }
    }
}