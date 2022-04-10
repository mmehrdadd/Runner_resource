namespace DefaultNamespace
{
    public class Enemy : Agent
    {
        protected override float DeltaTime => DefaultNamespace.DeltaTime.AgentDeltaTime;
    }
}