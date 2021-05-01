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

        public static MockEnvironmentMetadata? NextEnvironmentMetadata { get; set; }

        public override IEnvironmentMetadata GetEnvironmentMetadata(string resourceName)
        {
            var x = NextEnvironmentMetadata;
            NextEnvironmentMetadata = null;
            if(!ReferenceEquals(x, null))
            {
                x.SetResourceName(resourceName);
            }
            return x;
        }
    }
}