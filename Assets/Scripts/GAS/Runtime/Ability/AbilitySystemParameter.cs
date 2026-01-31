using System;
using GraphProcessor;
using UnityEngine;

namespace GAS.Runtime
{
    [Serializable]
    public class AbilitySystemParameter : ExposedParameter
    {
        [SerializeField] AbilitySystem val;

        public override object value { get => val; set => val = (AbilitySystem)value; }
        public override Type GetValueType() => typeof(AbilitySystem);
    }
}