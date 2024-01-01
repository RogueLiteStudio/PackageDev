using ECSLite;

public class MoveSystem : GroupUpdateSystemT<LogicContext, ILogic, MoveableComponent>
{
    public MoveSystem(LogicContext context) : base(context)
    {
    }

    protected override void OnExecuteEntity(Entity<ILogic> entity, MoveableComponent component)
    {
        throw new System.NotImplementedException();
    }
}
