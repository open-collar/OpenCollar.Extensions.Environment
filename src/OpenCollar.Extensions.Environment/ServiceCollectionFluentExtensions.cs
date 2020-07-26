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
 * Copyright © 2019-2020 Jonathan Evans (jevans@open-collar.org.uk).
 */

using Microsoft.Extensions.DependencyInjection;

using OpenCollar.Extensions.Validation;

namespace OpenCollar.Extensions.Environment
{
    /// <summary>
    ///     Extensions to the <see cref="IServiceCollection" /> type allowing the application service and related
    ///     services to be registered.
    /// </summary>
    /// <example>
    ///     <para>
    ///         The starting point is to create an implementation of the <see cref="IEnvironmentMetadata" /> object
    ///         (typically dervied from the <see cref="EnvironmentMetadata" /> base class). This can generate
    ///         environment information based on a "resource name" which can be used to determine the details of the environment.
    ///     </para>
    /// </example>
    public static class ServiceCollectionFluentExtensions
    {
        /// <summary>
        ///     Adds the application service and the specified environment metadata provider.
        /// </summary>
        /// <typeparam name="TEnvironmentMetadataProvider">
        ///     The type of the environment metadata provider that should be used to parse "resource names" and generate
        ///     <see cref="IEnvironmentMetadata" /> objects.
        /// </typeparam>
        /// <param name="serviceCollection">
        ///     The service collection to which to add the services.
        /// </param>
        /// <returns>
        ///     The service collection provided.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="serviceCollection" /> was <see langword="null" />.
        /// </exception>
        public static IServiceCollection AddApplicationService<TEnvironmentMetadataProvider>(this IServiceCollection serviceCollection) where TEnvironmentMetadataProvider : class, IEnvironmentMetadataProvider
        {
            serviceCollection.Validate(nameof(serviceCollection), ObjectIs.NotNull);

            // Register the implementation of the metadata provider.
            serviceCollection.AddSingleton<IEnvironmentMetadataProvider, TEnvironmentMetadataProvider>();

            // And register the application service itself.
            serviceCollection.AddSingleton<IApplicationService, ApplicationService>();

            return serviceCollection;
        }
    }
}