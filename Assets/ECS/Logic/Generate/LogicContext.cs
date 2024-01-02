
//工具生成，手动修改无效
public interface ILogicComponent : ILogic, ECSLite.IComponent{}
public interface ILogicUniqueComponent : ILogic, ILogicComponent, ECSLite.IUniqueComponent{}
public interface ILogicStaticComponent : ILogic, ECSLite.IStaticComponent{}

public class LogicContext : ECSLite.ContextT<ILogic>
{
    public LogicContext(int componentCount, int uniqueCount, int staticComponentCount) : base(componentCount, uniqueCount, staticComponentCount)
    {
    }
}