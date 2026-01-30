using GraphProcessor;
using UnityEngine;

namespace GAS.Editor
{
    public class AbilityGraphWindow : BaseGraphWindow
    {
        protected override void OnDestroy()
        {
            graphView?.Dispose();
        }

        protected override void InitializeWindow(BaseGraph graph)
        {
            titleContent = new GUIContent("技能编辑器");

            if (graphView == null)
                graphView = new AbilityGraphView(this);

            rootView.Add(graphView);
        }
    }
}