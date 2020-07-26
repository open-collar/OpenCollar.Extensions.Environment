namespace OpenCollar.Extensions.Environment.TESTS.Mocks
{
    public class MockEnvironmentMetadata : OpenCollar.Extensions.Environment.EnvironmentMetadata
    {
        public MockEnvironmentMetadata() : base()
        {
        }

        public MockEnvironmentMetadata(string? resourceName, string? environment, string? location, string? resourceType, string? instance, bool? isEmulated) : base(resourceName, environment, location, resourceType, instance, isEmulated)
        {
        }

        internal void SetResourceName(string resourceName)
        {
            ResourceName = resourceName;
        }
    }
}