using System.Collections.Generic;
using System.Reflection;

namespace GAS.Runtime
{
    interface IConditionalNode
    {
        IEnumerable<ConditionalNode> GetExecutedNodes();

        /// <summary>
        /// Provide a custom order for fields (so conditional links are always at the top of the node)
        /// </summary>
        /// <returns></returns>
        FieldInfo[] GetNodeFields();
    }
}