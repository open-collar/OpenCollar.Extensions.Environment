using Xunit;

namespace OpenCollar.Extensions.Environment.TESTS
{
    public class TestEnvironmentMetadataProviderBaseClass
    {
        [Fact]
        public void ConstructorTests()
        {
            const string resourceName = "AAAA-BBBB-CCCC-DDDD-EEEE";

            Mocks.MockEnvironmentMetadataProvider.NextEnvironmentMetadata = new Mocks.MockEnvironmentMetadata("AAAA", "1111", "CCCC", "DDDD", "EEEE", true);
            var x = new Mocks.MockEnvironmentMetadataProvider(resourceName);

            Assert.NotNull(x);
            var metadata = x.GetEnvironmentMetadata();
            Assert.NotNull(metadata);
            Assert.NotNull(metadata.ResourceName);
            Assert.Equal(resourceName, metadata.ResourceName);

            Assert.Equal("1111", metadata.Environment);
            Assert.Equal("CCCC", metadata.Location);
            Assert.Equal("DDDD", metadata.ResourceType);
            Assert.True(metadata.IsEmulated);
        }
    }
}