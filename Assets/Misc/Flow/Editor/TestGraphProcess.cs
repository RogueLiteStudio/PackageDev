using Flow;
using System;

[CustomFlowGraphProcess(typeof(TestGraph))]
public class TestGraphProcess : IFlowGraphProcess
{
    public Type EditorWindowType => typeof(TestGraphEditorWindow);

    public bool CheckIsValidNodeType(Type type)
    {
        return type.IsSubclassOf(typeof(TestNodeBase));
    }

    public FlowGraph OnCreateAction()
    {
        return null;
    }

    public void OnCreateSubGraph(FlowGraph graph, FlowSubGraph subGraph, FlowSubGraph prarent, FlowNode bindNode)
    {
    }

    public void OnSave(FlowGraph graph)
    {
    }
}
