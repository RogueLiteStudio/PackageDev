using UnityEditor;
using UnityEngine;
using Flow;
using UnityEngine.UIElements;

[EditorWindowTitle(title = "Test Graph Editor")]
public class TestGraphEditorWindow : EditorWindow
{
    public FlowGraphEditor graphEditor;
    public TestGraph graph;

    private void OnEnable()
    {
        if (graphEditor)
        {
            graphEditor.RefreshView();
        }
    }

    private void OnDestroy()
    {
        if (graphEditor != null)
        {
            DestroyImmediate(graphEditor);
            graphEditor = null;
        }
    }

    [MenuItem("Tools/创建Graph")]
    static void CreateGarap()
    {
        string path = "Assets/Flow/TestGraph.asset";
        var graph = AssetDatabase.LoadAssetAtPath<TestGraph>(path);
        if (graph == null)
        {
            graph = CreateInstance<TestGraph>();
            var subGraph = GraphCreateUtil.CreateSubGraph(graph, true);
            var entry = new TestEntry();
            GraphCreateUtil.CreateNode(subGraph, entry, new Rect(Vector2.zero, new Vector2(100, 100)));
            AssetDatabase.CreateAsset(graph, path);
            AssetDatabase.SaveAssets();
        }
        var window = GetWindow<TestGraphEditorWindow>();
        window.graph = graph;
        window.graphEditor = CreateInstance<FlowGraphEditor>();
        window.graphEditor.Graph = graph.SubGraphs[0];
        window.graphEditor.window = window;
        window.graphEditor.RefreshView();
    }
}
