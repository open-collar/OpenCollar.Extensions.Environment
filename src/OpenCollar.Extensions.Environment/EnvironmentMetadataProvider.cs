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

using System;
using System.Collections.Generic;
using System.Linq;

using OpenCollar.Extensions.Validation;

namespace OpenCollar.Extensions.Environment
{
    /// <summary>
    ///     A base class from environment metadata providers that implements the basic functionality.
    /// </summary>
    /// <seealso cref="OpenCollar.Extensions.Environment.IEnvironmentMetadataProvider" />
    public abstract class EnvironmentMetadataProvider : IEnvironmentMetadataProvider
    {
        /// <summary>
        ///     The types of environment available, keyed on all their acronyms.
        /// </summary>
        private readonly Dictionary<string, EnvironmentType> _environmentsByAcronym;

        /// <summary>
        ///     The types of environment available, keyed on their definitive names.
        /// </summary>
        private readonly Dictionary<string, EnvironmentType> _environmentsByName;

        /// <summary>
        ///     The type of the environment in which the application is running.
        /// </summary>
        private readonly EnvironmentType _environmentType;

        /// <summary>
        ///     The metadata describing the application and its environment.
        /// </summary>
        private readonly IEnvironmentMetadata _metadata;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnvironmentMetadataProvider" /> class.
        /// </summary>
        /// <param name="applicationResourceName">
        ///     Name of the application resource.
        /// </param>
        /// <param name="environmentTypes">
        ///     The environment types.
        /// </param>
        /// <exception cref="BadImplementationException">
        ///     <see cref="GetEnvironmentMetadata(string)" /> returned <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="environmentTypes" /> contains a <see langword="null" /> value.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="applicationResourceName" /> is <see langword="null" />.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        ///     <paramref name="applicationResourceName" /> is zero-length of contains only whote-space characters.
        /// </exception>
        protected EnvironmentMetadataProvider(string applicationResourceName, params EnvironmentType[] environmentTypes)
        {
            applicationResourceName.Validate(applicationResourceName, StringIs.NotNullEmptyOrWhiteSpace);

            _environmentsByName = new Dictionary<string, EnvironmentType>(StringComparer.OrdinalIgnoreCase);
            _environmentsByAcronym = new Dictionary<string, EnvironmentType>(StringComparer.OrdinalIgnoreCase);
            var index = 0;
            foreach(var environmentType in environmentTypes)
            {
                if(ReferenceEquals(environmentType, null))
                {
                    throw new ArgumentException(string.Format(System.Globalization.CultureInfo.InvariantCulture, Resources.Exceptions.NullValueAtIndex, nameof(environmentTypes), index), nameof(environmentTypes));
                }
                _environmentsByName.Add(environmentType.Name, environmentType);
                foreach(var acronym in environmentType.Acronyms)
                {
                    _environmentsByAcronym.Add(acronym, environmentType);
                }
                ++index;
            }

            var metadata = GetEnvironmentMetadata(applicationResourceName);

            if(ReferenceEquals(metadata, null))
            {
                throw new BadImplementationException(string.Format(System.Globalization.CultureInfo.InvariantCulture, Resources.Exceptions.MethodReturnNull, nameof(GetEnvironmentMetadata)));
            }

            _metadata = metadata;

            var applicationEnvironmentType = GetEnvironmentType(_metadata);

            if(ReferenceEquals(applicationEnvironmentType, null))
            {
                throw new BadImplementationException(string.Format(System.Globalization.CultureInfo.InvariantCulture, OpenCollar.Extensions.Environment.Resources.Exceptions.MethodReturnNull, nameof(GetEnvironmentType)));
            }

            _environmentType = applicationEnvironmentType;
        }

        /// <summary>
        ///     Gets the types of environment in which an application or resource may be found .
        /// </summary>
        /// <value>
        ///     The environment in which an application or resource may be found.
        /// </value>
        public IEnumerable<EnvironmentType> EnvironmentTypes { get { return _environmentsByName.Values.ToArray(); } }

        /// <summary>
        ///     Gets an object that provides basic metadata about the environment in which the application is running.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <value>
        ///     An object that provides basic metadata about the environment in which the application is running.
        /// </value>
        public IEnvironmentMetadata GetEnvironmentMetadata()
        {
            return _metadata;
        }

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
        public abstract IEnvironmentMetadata GetEnvironmentMetadata(string resourceName);

        /// <summary>
        ///     Gets the type of the environment to which the metadata object refers.
        /// </summary>
        /// <param name="metadata">
        ///     The metadata object for which to get an environment.
        /// </param>
        /// <returns>
        ///     The environment type for the metadata object given, or <see langword="null" /> if no match could be found.
        /// </returns>
        public EnvironmentType? GetEnvironmentType(IEnvironmentMetadata metadata)
        {
            metadata.Validate(nameof(metadata), ObjectIs.NotNull);

            var environment = metadata.Environment;
            if(ReferenceEquals(environment, null))
            {
                return null;
            }

            if(_environmentsByAcronym.TryGetValue(environment, out var environmentType))
            {
                return environmentType;
            }

            if(_environmentsByName.TryGetValue(environment, out environmentType))
            {
                return environmentType;
            }

            return null;
        }

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
        /// <exception cref="BadImplementationException">
        ///     <see cref="GetEnvironmentMetadata(string)" /> returned <see langword="null" />.
        /// </exception>
        public string? GetResourceEnvironment(string resourceName)
        {
            var metadata = GetEnvironmentMetadata(resourceName);

            if(ReferenceEquals(metadata, null))
            {
                throw new BadImplementationException(string.Format(System.Globalization.CultureInfo.InvariantCulture, OpenCollar.Extensions.Environment.Resources.Exceptions.MethodReturnNull, nameof(GetEnvironmentMetadata)));
            }

            return metadata.Environment;
        }

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
        public virtual bool? IsValidEnvironmentPairing(IEnvironmentMetadata environmentMetadata, string resourceName)
        {
            if(ReferenceEquals(_metadata.Environment, null))
            {
                return null;
            }

            var otherResource = GetEnvironmentMetadata(resourceName);

            if(ReferenceEquals(otherResource, null))
            {
                return null;
            }

            if(ReferenceEquals(otherResource.Environment, null))
            {
                return null;
            }

            var otherEnvironment = GetEnvironmentType(otherResource);

            if(ReferenceEquals(otherEnvironment, null))
            {
                return null;
            }

            return _environmentType == otherEnvironment;
        }
    }
}