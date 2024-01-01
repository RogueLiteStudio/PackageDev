public class TimeSystem : ECSLite.IUpdateSystem
{
    public LogicContext Context { get; private set; }

    public TimeSystem(LogicContext context)
    {
        Context = context;
        var time = context.AddStaticComponent<LogicTimeComponent>();
        time.TimeStep = 1 / 30f;
    }

    public void OnUpdate()
    {
        var time = Context.GetStaticComponent<LogicTimeComponent>();
        time.Frame++;
        time.DeltaTime = time.TimeStep * time.TimeScale;
        time.Time += time.DeltaTime;
        time.TimeScale = 1;
    }
}
