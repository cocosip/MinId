namespace SharpAbp.MinId
{
    public static class MinIdDbProperties
    {
        public static string DbTablePrefix { get; set; } = "MinId";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "MinId";
    }
}
