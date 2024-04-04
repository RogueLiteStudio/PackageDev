using Flow;
using UnityEditor;
using UnityEngine;

[EditorWindowTitle(title = "Test Graph Editor")]
public class TestGraphEditorWindow : TFlowGraphWindow<TestGraph>
{

    [MenuItem("Tools/创建Graph")]
    static void CreateGarap()
    {
        string path = "Assets/Flow/TestGraph.asset";
        var graph = AssetDatabase.LoadAssetAtPath<TestGraph>(path);
        if (graph == null)
        {
            graph = CreateInstance<TestGraph>();
            var subGraph = GraphCreateUtil.CreateSubGraph(graph, true, null, null);
            var entry = new TestEntry();
            GraphCreateUtil.CreateNode(subGraph, entry, new Rect(Vector2.zero, new Vector2(100, 100)));
            AssetDatabase.CreateAsset(graph, path);
            AssetDatabase.SaveAssets();
        }
        OpenGraph(graph);
    }
}
