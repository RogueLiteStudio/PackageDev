using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class VisualElementWindow : EditorWindow
{
    [MenuItem("Tools/VisualElementWindow")]
    static void ShowWindow()
    {
        GetWindow<VisualElementWindow>();
    }
    public void CreateGUI()
    {
        var assetField = new NamedAsset.Editor.NamedAssetField("test");
        assetField.AssetType = typeof(GameObject);
        rootVisualElement.Add(assetField);

        var template = new ObjectField("Template");
        template.objectType = typeof(GameObject);
        rootVisualElement.Add(template);
    }
}
