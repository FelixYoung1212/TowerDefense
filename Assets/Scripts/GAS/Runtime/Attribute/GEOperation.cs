using System;

namespace GAS.Runtime
{
    public enum GEOperation
    {
        Add = 0,
        Minus = 3,
        Multiply = 1,
        Divide = 4,
        Override = 2
    }

    [Flags]
    public enum SupportedOperation : byte
    {
        None = 0,
        Add = 1 << GEOperation.Add,
        Minus = 1 << GEOperation.Minus,
        Multiply = 1 << GEOperation.Multiply,
        Divide = 1 << GEOperation.Divide,
        Override = 1 << GEOperation.Override,
        All = Add | Minus | Multiply | Divide | Override
    }
}