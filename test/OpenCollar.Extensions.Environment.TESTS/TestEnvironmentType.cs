/*
 * This file is part of OpenCollar.Extensions.Configuration.
 *
 * OpenCollar.Extensions.Configuration is free software: you can redistribute it
 * and/or modify it under the terms of the GNU General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or (at your
 * option) any later version.
 *
 * OpenCollar.Extensions.Configuration is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public
 * License for more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * OpenCollar.Extensions.Configuration.  If not, see <https://www.gnu.org/licenses/>.
 *
 * Copyright © 2019-2021 Jonathan Evans (jevans@open-collar.org.uk).
 */

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