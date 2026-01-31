using GraphProcessor;
using UnityEditor;
using Status = UnityEngine.UIElements.DropdownMenuAction.Status;

namespace GAS.Editor
{
    public class AbilityGraphWindowToolBarView : ToolbarView
    {
        ToolbarButtonData m_ShowParameters;

        public AbilityGraphWindowToolBarView(BaseGraphView graphView) : base(graphView)
        {
        }

        protected override void AddButtons()
        {
            bool exposedParamsVisible = graphView.GetPinnedElementStatus<ExposedParameterView>() != Status.Hidden;
            m_ShowParameters = AddToggle("打开参数面板", exposedParamsVisible,
                (v) => graphView.ToggleView<ExposedParameterView>());

            AddButton("Show In Project", () => EditorGUIUtility.PingObject(graphView.graph), false);
        }

        public override void UpdateButtonStatus()
        {
            if (m_ShowParameters != null)
                m_ShowParameters.value = graphView.GetPinnedElementStatus<ExposedParameterView>() != Status.Hidden;
        }
    }
}