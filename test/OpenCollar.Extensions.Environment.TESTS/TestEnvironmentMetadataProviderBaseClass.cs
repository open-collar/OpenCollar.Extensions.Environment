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