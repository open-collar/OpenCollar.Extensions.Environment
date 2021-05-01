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

using System.Collections.Generic;

namespace OpenCollar.Extensions.Environment
{
    /// <summary>
    ///     The public interface of a service that provides the environment metadata for a given application.
    /// </summary>
    /// <remarks>
    ///     This must be implemented by the consumer - there are no common patterns. This might involve parsing host
    ///     names, environment variables and maybe supplied configuration.
    /// </remarks>
    public interface IEnvironmentMetadataProvider
    {
        /// <summary>
        ///     Gets the types of environment in which an application or resource may be found .
        /// </summary>
        /// <value>
        ///     The environment in which an application or resource may be found.
        /// </value>
        public IEnumerable<EnvironmentType> EnvironmentTypes { get; }

        /// <summary>
        ///     Gets an object that provides basic metadata about the environment in which the application is running.
        /// </summary>
        /// <value>
        ///     An object that provides basic metadata about the environment in which the application is running.
        /// </value>
        public IEnvironmentMetadata GetEnvironmentMetadata();

        /// <summary>
        ///     Gets an object that provides basic metadata about the resource specified.
        /// </summary>
        /// <param name="resourceName">
        ///     The name of the resource for which to determine the environment metadata.
        /// </param>
        /// <returns>
        /// </returns>
        /// <value>
        ///     An object that provides basic metadata about the resource specified.
        /// </value>
        public IEnvironmentMetadata GetEnvironmentMetadata(string resourceName);

        /// <summary>
        ///     Gets the type of the environment to which the metadata object refers.
        /// </summary>
        /// <param name="metadata">
        ///     The metadata object for which to get an environment.
        /// </param>
        /// <returns>
        ///     The environment type for the metadata object given, or <see langword="null" /> if no match could be found.
        /// </returns>
        public EnvironmentType? GetEnvironmentType(IEnvironmentMetadata metadata);

        /// <summary>
        ///     Gets the environment from a resource name.
        /// </summary>
        /// <param name="resourceName">
        ///     The name of the resource for which to determine the environment.
        /// </param>
        /// <returns>
        ///     The environment name for the environment, e.g. "PDN", "UAT" or "DEV" - this is left up to the
        ///     implementing application. Environment names are always treated as case insensitive.
        /// </returns>
        public string? GetResourceEnvironment(string resourceName);

        /// <summary>
        ///     Determines whether the specified resource should be used with the environment metadata given.
        /// </summary>
        /// <param name="environmentMetadata">
        ///     The metadata defining the application environment.
        /// </param>
        /// <param name="resourceName">
        ///     The name of the resource to validate.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the specified resource should be used with the environment metadata given;
        ///     otherwise, <see langword="false" />. <see langword="null" /> will be returned if the value could not be determined.
        /// </returns>
        public bool? IsValidEnvironmentPairing(IEnvironmentMetadata environmentMetadata, string resourceName);
    }
}