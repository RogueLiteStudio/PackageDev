
//工具生成，手动修改无效
public class LogicECS
{
    private static int s_ComponentCount = 2;
    private static int s_UniqueComponentCount = 1;
    private static int s_StatcicComponentCount = 1;
    public static int ComponentCount => s_ComponentCount;
    public static int StaticComponentCount => s_StatcicComponentCount;
    static LogicECS()
    {
        ECSLite.StaticComponentIdentity<LogicTimeComponent>.Id = 0;
        ECSLite.ComponentIdentity<AttackableComponent>.Id = 0;
        ECSLite.ComponentIdentity<MoveableComponent>.Id = 1;
        ECSLite.ComponentIdentity<UniqueComponent>.Id = 2;
        ECSLite.ComponentIdentity<UniqueComponent>.Unique = true;
        LogicComponentReset.Init();
    }
    public static LogicContext CreateContext()
    {
        LogicContext context = new LogicContext(s_ComponentCount, s_UniqueComponentCount, s_StatcicComponentCount);
        context.InitFlagComponentCollector<AttackableComponent>();
        context.InitComponentCollector<MoveableComponent>();
        context.InitUniqueComponentCollector<UniqueComponent>();
        return context;
    }
}