using GAS.Runtime;
using GraphProcessor;
using UnityEditor;
using UnityEngine.UIElements;

namespace GAS.Editor
{
    [CustomEditor(typeof(AbilityGraph), true)]
    public class AbilityGraphAssetInspector : GraphInspector
    {
        protected override void CreateInspector()
        {
            base.CreateInspector();

            root.Add(new Button(() => EditorWindow.GetWindow<AbilityGraphWindow>().InitializeGraph(target as AbilityGraph))
            {
                text = "打开技能编辑器"
            });
        }
    }
}