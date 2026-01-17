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
            float waitSec = GetInputValue(nameof(waitSeconds), waitSeconds);
            WaitNodeHelper.Instance.WaitForSeconds(waitSec, OnExecuteCompleted);
        }
    }
}