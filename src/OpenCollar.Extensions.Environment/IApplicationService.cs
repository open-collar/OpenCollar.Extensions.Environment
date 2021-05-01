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

namespace OpenCollar.Extensions.Environment
{
    /// <summary>
    ///     The public interface of a service that provides information and utilities allowing metadata about an
    ///     application to be shared throught an application's components.
    /// </summary>
    public interface IApplicationService
    {
        /// <summary>
        ///     Gets an object that provides basic metadata about the environment in which the application is running.
        /// </summary>
        /// <value>
        ///     An object that provides basic metadata about the environment in which the application is running.
        ///     Environment names are always treated as case insensitive.
        /// </value>
        public IEnvironmentMetadata Environment { get; }

        /// <summary>
        ///     Gets the environment from a resource name.
        /// </summary>
        /// <param name="resourceName">
        ///     The environment from a resource name. This could be a database name, a server name or similar.
        /// </param>
        /// <returns>
        ///     The environment name for the resource given, e.g. "PDN", "UAT" or "DEV" - this is left up to the
        ///     implementing application. <see langword="null" /> will be returned if the value could not be determined.
        ///     Environment names are always treated as case insensitive.
        /// </returns>
        public string? GetResourceEnvironment(string resourceName);

        /// <summary>
        ///     Determines whether the specified resource should be used in the application environment.
        /// </summary>
        /// <param name="resourceName">
        ///     The name of the resource to validate.
        /// </param>
        /// <param name="permitFuzzyResults">
        ///     If set to <see langword="true" /> unknown environments (where the environment name is identified as
        ///     <see langword="null" />) are permitted to match with anything.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the specified resource should be used in the application environment;
        ///     otherwise, <see langword="false" />. <see langword="null" /> will be returned if the value could not be
        ///     determined and <paramref name="permitFuzzyResults" /> is <see langword="true" />.
        /// </returns>
        public bool? IsValidEnvironmentPairing(string resourceName, bool permitFuzzyResults = false);

        /// <summary>
        ///     Validates the pairing of the resource named and the current environment, throwing a
        ///     <see cref="MismatchedEnvironmentException" /> exception if they are deemed incompatible.
        /// </summary>
        /// <param name="resourceName">
        ///     The name of the resource to validate.
        /// </param>
        /// <param name="permitFuzzyResults">
        ///     If set to <see langword="true" /> unknown environments (where the environment name is identified as
        ///     <see langword="null" />) are permitted to match with anything.
        /// </param>
        /// <exception cref="MismatchedEnvironmentException">
        ///     The given resource is not compatible with application environment.
        /// </exception>
        public void ValidateResourcePairing(string resourceName, bool permitFuzzyResults = false);
    }
}