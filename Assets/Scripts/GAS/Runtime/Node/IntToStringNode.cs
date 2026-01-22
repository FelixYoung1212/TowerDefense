using XNode;

namespace GAS.Runtime
{
    public class IntToStringNode : Node
    {
        [Input] public int input;
        [Output] public string output;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == "output")
            {
                var inputValue = GetInputValue("input", this.input);
                return inputValue.ToString();
            }

            return null;
        }
    }
}