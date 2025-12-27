using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Ability
{
    public class WaitSecondsNode : WaitNode
    {
        [Input] public float waitSeconds;

        public override void Execute()
        {
            CoroutineManager.Instance.WaitForSeconds(waitSeconds, OnExecuteCompleted);
        }
    }
}