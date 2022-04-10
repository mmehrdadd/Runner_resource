using System;

namespace DefaultNamespace
{
    public class PlayerAgent : Agent
    {
        protected override float DeltaTime
        {
            get => DefaultNamespace.DeltaTime.PlayerDeltaTime;
        }

    }
}