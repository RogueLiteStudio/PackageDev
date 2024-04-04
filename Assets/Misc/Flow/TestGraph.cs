using Flow;
using System;

public class TestGraph : FlowGraph
{
    public override bool CheckIsValidNodeType(Type type)
    {
        return type.IsSubclassOf(typeof(TestNodeBase));
    }

}