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