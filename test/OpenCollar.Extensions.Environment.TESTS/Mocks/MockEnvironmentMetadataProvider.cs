namespace OpenCollar.Extensions.Environment.TESTS.Mocks
{
    public sealed class MockEnvironmentMetadataProvider : OpenCollar.Extensions.Environment.EnvironmentMetadataProvider
    {
        public MockEnvironmentMetadataProvider(string resourceName) : base(resourceName,

            new EnvironmentType("1111", "1-1-1-1", int.MaxValue, "1", "11"),

            new EnvironmentType("2222", "2-2-2-2", 1000, "2", "22"),

            new EnvironmentType("3333", "3-3-3-3", 500, "3", "33"),

            new EnvironmentType("4444", "4-4-4-4", 100, "4", "44"))

        {
        }

        public static MockEnvironmentMetadata NextEnvironmentMetadata { get; set; }

        public override IEnvironmentMetadata GetEnvironmentMetadata(string resourceName)
        {
            var x = NextEnvironmentMetadata;
            NextEnvironmentMetadata = null;
            x.SetResourceName(resourceName);
            return x;
        }
    }
}