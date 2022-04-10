namespace DefaultNamespace
{
    public static class DeltaTime
    {
        private static float defaultDelta = 1f;

        public static float DefaultDelta=> defaultDelta;

        public static float AgentDeltaTime = 1f;
        public static float PlayerDeltaTime = 1f;
        public static float EnvDeltaTime = 1f;

        public static void RestAll()
        {
            AgentDeltaTime = PlayerDeltaTime = EnvDeltaTime = defaultDelta;
        }

        public static void RestAgentsDeltaTime() => AgentDeltaTime = defaultDelta;
        public static void RestPlayerDeltaTime() => PlayerDeltaTime = defaultDelta;
    }
}