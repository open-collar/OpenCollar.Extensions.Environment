using Xunit;

namespace OpenCollar.Extensions.Environment.TESTS
{
    public class TestEnvironmentType
    {
        [Fact]
        public void ConstructorTests()
        {
            var x = new EnvironmentType("AAAA", "BBBB", 0, "A1111", "A2222", "A3333");

            Assert.NotNull(x);
            Assert.Equal("AAAA", x.Name);
            Assert.Equal("BBBB", x.Description);
            Assert.Equal((uint)0, x.Sensitivity);
            Assert.Contains("A1111", x.Acronyms);
            Assert.Contains("A2222", x.Acronyms);
            Assert.Contains("A3333", x.Acronyms);
        }

        [Fact]
        public void EqualityTests()
        {
            var x = new EnvironmentType("AAAA", "BBBB", 0, "A1111", "A2222", "A3333");
            var y = new EnvironmentType("AAAA", "BBBB", 1000, "A1111", "A2222", "A3333");
            var z = new EnvironmentType("BBBB", "BBBB", 1000, "A1111", "A2222", "A3333");

            Assert.True(x == y);
            Assert.False(y == z);
            Assert.False(x == z);
            Assert.True(x.Equals(y));
            Assert.False(y.Equals(z));
            Assert.False(x.Equals(z));
        }
    }
}