using XNode;

namespace GAS.Runtime
{
    public class IntToFloatNode : Node
    {
        [Input(connectionType = ConnectionType.Override)] public int input;
        [Output] public float output;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == "output")
            {
                var inputValue = GetInputValue("input", this.input);
                return (float)inputValue;
            }

            return 0;
        }
    }
}