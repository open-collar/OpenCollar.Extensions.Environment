namespace OpenCollar.Extensions.Environment
{
    /// <summary>
    ///     The interface for objects that represent the environment in which an application is hosted.
    /// </summary>
    public interface IEnvironmentMetadata
    {
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
        public string? Environment { get; }

        /// <summary>
        ///     Gets the instance of the resource.
        /// </summary>
        /// <value>
        ///     The instance of the resource. <see langword="null" /> will be returned if the value could not be determined.
        /// </value>
        /// <example>
        ///     E.g. "100" or "A".
        /// </example>
        public string? Instance { get; }

        /// <summary>
        ///     Gets a value indicating whether the host is locally emulated (rather than running on a genuine environment).
        /// </summary>
        /// <value>
        ///     <see langword="true" /> if the host is locally emulated (rather than running on a genuine environment).;
        ///     otherwise, <see langword="false" />. <see langword="null" /> will be returned if the value could not be determined.
        /// </value>
        public bool? IsEmulated { get; }

        /// <summary>
        ///     Gets the location of the resource.
        /// </summary>
        /// <value>
        ///     The location of the resource. <see langword="null" /> will be returned if the value could not be determined.
        /// </value>
        /// <example>
        ///     E.g. "East US 2" or "UK South".
        /// </example>
        public string? Location { get; }

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
        public string? ResourceName { get; }

        /// <summary>
        ///     Gets the kind of Azure application hosting this service.
        /// </summary>
        /// <value>
        ///     The kind of Azure application hosting this service. <see langword="null" /> will be returned if the
        ///     value could not be determined.
        /// </value>
        public string? ResourceType { get; }
    }
}