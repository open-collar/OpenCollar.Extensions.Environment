using System.Diagnostics;

namespace OpenCollar.Extensions.Environment
{
    /// <summary>
    ///     A minimal implementation of the <see cref="OpenCollar.Extensions.Environment.IEnvironmentMetadata" />
    ///     interface that can be used a base class.
    /// </summary>
    /// <seealso cref="OpenCollar.Extensions.Environment.IEnvironmentMetadata" />
    [DebuggerDisplay("{ResourceName,nq}")]
    public abstract class EnvironmentMetadata : IEnvironmentMetadata
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EnvironmentMetadata" /> class.
        /// </summary>
        protected EnvironmentMetadata() { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnvironmentMetadata" /> class.
        /// </summary>
        /// <param name="resourceName">
        ///     The name of the resource. <see langword="null" /> will be accepted if the value could not be determined.
        /// </param>
        /// <param name="environment">
        ///     The functional environment in which the adapter is hosted. <see langword="null" /> will be accepted if
        ///     the value could not be determined. Environment names are always treated as case insensitive.
        /// </param>
        /// <param name="location">
        ///     The location of the resource. <see langword="null" /> will be accepted if the value could not be determined.
        /// </param>
        /// <param name="resourceType">
        ///     The type of the resource, for example "Container", "WebApp", "Database", etc. <see langword="null" />
        ///     will be accepted if the value could not be determined.
        /// </param>
        /// <param name="instance">
        ///     The instance of the resource. <see langword="null" /> will be accepted if the value could not be determined.
        /// </param>
        /// <param name="isEmulated">
        ///     <see langword="true" /> if the host is locally emulated (rather than running on a genuine environment).;
        ///     otherwise, <see langword="false" />. <see langword="null" /> will be accepted if the value could not be determined.
        /// </param>
        protected EnvironmentMetadata(string? resourceName, string? environment, string? location, string? resourceType, string? instance, bool? isEmulated)
        {
            ResourceName = resourceName;
            Environment = environment;
            Location = location;
            ResourceType = resourceType;
            Instance = instance;
            IsEmulated = isEmulated;
        }

        /// <summary>
        ///     Gets the functional environment in which the adapter is hosted.
        /// </summary>
        /// <value>
        ///     The functional environment in which the adapter is hosted. <see langword="null" /> will be returned if
        ///     the value could not be determined. Environment names are always treated as case insensitive.
        /// </value>
        /// <example>
        ///     E.g. "PDN", "UAT" or "DEV" - this is left up to the implementing application.
        /// </example>
        public string? Environment { get; protected set; }

        /// <summary>
        ///     Gets the instance of the resource.
        /// </summary>
        /// <value>
        ///     The instance of the resource. <see langword="null" /> will be returned if the value could not be determined.
        /// </value>
        /// <example>
        ///     E.g. "100" or "A".
        /// </example>
        public string? Instance { get; protected set; }

        /// <summary>
        ///     Gets a value indicating whether the host is locally emulated (rather than running on a genuine environment).
        /// </summary>
        /// <value>
        ///     <see langword="true" /> if the host is locally emulated (rather than running on a genuine environment).;
        ///     otherwise, <see langword="false" />. <see langword="null" /> will be returned if the value could not be determined.
        /// </value>
        public bool? IsEmulated { get; protected set; }

        /// <summary>
        ///     Gets the location of the resource.
        /// </summary>
        /// <value>
        ///     The location of the resource. <see langword="null" /> will be returned if the value could not be determined.
        /// </value>
        /// <example>
        ///     E.g. "East US 2" or "UK South".
        /// </example>
        public string? Location { get; protected set; }

        /// <summary>
        ///     Gets the name of the resource.
        /// </summary>
        /// <value>
        ///     The name of the resource. <see langword="null" /> will be returned if the value could not be determined.
        /// </value>
        /// <remarks>
        ///     The hostname may well encode all of the other information in this object.
        /// </remarks>
        /// <example>
        ///     E.g. "uk-dev-db-1" or "east-webapp-prod-10".
        /// </example>
        public string? ResourceName { get; protected set; }

        /// <summary>
        ///     Gets the type of the resource.
        /// </summary>
        /// <value>
        ///     The type of the resource, for example "Container", "WebApp", "Database", etc. <see langword="null" />
        ///     will be returned if the value could not be determined.
        /// </value>
        /// <remarks>
        ///     E.g. "Container", "WebApp" or "Database".
        /// </remarks>
        public string? ResourceType { get; protected set; }
    }
}