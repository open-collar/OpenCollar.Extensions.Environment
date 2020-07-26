using Xunit;

namespace OpenCollar.Extensions.Environment.TESTS
{
    public class TestEnvironmentMetadataBaseClass
    {
        [Fact]
        public void ConstructorTests_Default()
        {
            var x = new Mocks.MockEnvironmentMetadata();

            Assert.NotNull(x);
            Assert.Null(x.Environment);
            Assert.Null(x.Instance);
            Assert.Null(x.IsEmulated);
            Assert.Null(x.Location);
            Assert.Null(x.ResourceName);
            Assert.Null(x.ResourceType);
        }

        [Fact]
        public void ConstructorTests_Full()
        {
            var x = new Mocks.MockEnvironmentMetadata("AAAA", "BBBB", "CCCC", "DDDD", "EEEE", true);

            Assert.NotNull(x);
            Assert.Equal("AAAA", x.ResourceName);
            Assert.Equal("BBBB", x.Environment);
            Assert.Equal("CCCC", x.Location);
            Assert.Equal("DDDD", x.ResourceType);
            Assert.Equal("EEEE", x.Instance);
            Assert.Equal(true, x.IsEmulated);
        }
    }
}