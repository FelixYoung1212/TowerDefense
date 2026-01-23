using XNode;

namespace GAS.Runtime
{
    public class MathNode : Node
    {
        [Input(connectionType = ConnectionType.Override)] public float a;

        [Input(connectionType = ConnectionType.Override)] public float b;

        [Output] public float result;
        public MathType mathType = MathType.Add;

        public enum MathType
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }

        public override object GetValue(NodePort port)
        {
            float aValue = GetInputValue(nameof(a), a);
            float bValue = GetInputValue(nameof(b), b);

            if (port.fieldName == nameof(result))
            {
                switch (mathType)
                {
                    case MathType.Add:
                    default: return aValue + bValue;
                    case MathType.Subtract: return aValue - bValue;
                    case MathType.Multiply: return aValue * bValue;
                    case MathType.Divide: return aValue / bValue;
                }
            }

            return 0f;
        }
    }
}