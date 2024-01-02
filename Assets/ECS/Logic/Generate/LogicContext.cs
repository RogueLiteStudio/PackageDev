public interface ILogicComponent : ILogic, ECSLite.IComponent
{
}

public interface ILogicUniqueComponent : ILogic, ECSLite.IUniqueComponent
{
}

public interface ILogicStaticComponent : ILogic, ECSLite.IStaticComponent
{
}

public class LogicContext : ECSLite.ContextT<ILogic>
{
    public LogicContext(int componentCount, int uniqueCount, int staticComponentCount) : 
        base(componentCount, uniqueCount, staticComponentCount)
    {
    }
}