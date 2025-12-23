using XNode;

namespace DefaultNamespace.Ability
{
    public abstract class ExecuteNode : Node
    {
        [Input] public ExecuteLink executed;
        [Output] public ExecuteLink execute;
    }
}