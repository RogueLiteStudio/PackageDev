
//工具生成，手动修改无效
public partial class LogicComponentReset
{
    public static void Init()
    {
        ECSLite.ComponentReset<MoveableComponent>.OnReset = OnReset;
    }
}