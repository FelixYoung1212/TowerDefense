using GraphProcessor;
using UnityEditor;

namespace GAS.Editor
{
    public class AbilityGraphView : BaseGraphView
    {
        public AbilityGraphView(EditorWindow window) : base(window)
        {
            Add(new AbilityGraphWindowToolBarView(this));
        }
    }
}