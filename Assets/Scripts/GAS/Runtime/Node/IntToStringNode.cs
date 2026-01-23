using XNode;

namespace GAS.Runtime
{
    public class IntToStringNode : Node
    {
        [Input(connectionType = ConnectionType.Override)] public int input;
        [Output] public string output;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(output))
            {
                var inputValue = GetInputValue(nameof(input), this.input);
                return inputValue.ToString();
            }

            return null;
        }
    }
}