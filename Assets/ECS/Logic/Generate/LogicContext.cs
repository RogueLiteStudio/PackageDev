using ECSLite;

public class LogicContext : ContextT<ILogic>
{
    public LogicContext(int componentCount, int uniqueCount, int staticComponentCount) : 
        base(componentCount, uniqueCount, staticComponentCount)
    {
    }
}