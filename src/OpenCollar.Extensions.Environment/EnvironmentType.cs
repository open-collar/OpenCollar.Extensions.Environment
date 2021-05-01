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

using OpenCollar.Extensions.Validation;

namespace OpenCollar.Extensions.Environment
{
    /// <summary>
    ///     A class representing an environment to which a resource may belong.
    /// </summary>
    public sealed class EnvironmentType
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EnvironmentType" /> class.
        /// </summary>
        /// <param name="name">
        ///     The name of the environment, for example "Production" or "QA".
        /// </param>
        /// <param name="description">
        ///     The description of the environment, for example "The production environment" or "Quality and performance
        ///     testing environment".
        /// </param>
        /// <param name="sensitivity">
        ///     The sensitivity of the environment where zero means that an environment is completely disposable and
        ///     there is no impact of damaging the data and configuration, and greater values, up to
        ///     <see cref="int.MaxValue" /> indicate increasing criticality up to that of production environments.
        /// </param>
        /// <param name="acronyms">
        ///     The acronyms that might be used to represent the environment, e.g. "P", "PDN", "PRD", "PROD" may all be
        ///     used for the production environment.
        /// </param>
        public EnvironmentType(string name, string description, uint sensitivity, params string[] acronyms)
        {
            name.Validate(nameof(name), StringIs.NotNullEmptyOrWhiteSpace);
            description.Validate(nameof(description), StringIs.NotNullEmptyOrWhiteSpace);
            acronyms.Validate(nameof(acronyms), ObjectIs.NotNull);

            Name = name;
            Description = description;
            Sensitivity = sensitivity;
            Acronyms = acronyms;
        }

        /// <summary>
        ///     Gets the acronyms that might be used to represent the environment.
        /// </summary>
        /// <value>
        ///     The acronyms that might be used to represent the environment, e.g. "P", "PDN", "PRD", "PROD" may all be
        ///     used for the production environment.
        /// </value>
        public IReadOnlyList<string> Acronyms { get; }

        /// <summary>
        ///     Gets the description of the environment.
        /// </summary>
        /// <value>
        ///     The description of the environment, for example "The production environment" or "Quality and performance
        ///     testing environment".
        /// </value>
        public string Description { get; }

        /// <summary>
        ///     Gets the name of the environment.
        /// </summary>
        /// <value>
        ///     The name of the environment, for example "Production" or "QA".
        /// </value>
        public string Name { get; }

        /// <summary>
        ///     Gets the sensitivity or criticality of the environment. Higher numbers indicate greater sensitivity.
        /// </summary>
        /// <value>
        ///     The sensitivity of the environment where zero means that an environment is completely disposable and
        ///     there is no impact of damaging the data and configuration, and greater values, up to
        ///     <see cref="int.MaxValue" /> indicate increasing criticality up to that of production environments.
        /// </value>
        public uint Sensitivity { get; }

        /// <summary>
        ///     Returns a value that indicates whether two
        ///     <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> objects have different values.
        /// </summary>
        /// <param name="left">
        ///     The first value to compare.
        /// </param>
        /// <param name="right">
        ///     The second value to compare.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal;
        ///     otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator !=(EnvironmentType left, EnvironmentType right) => !Equals(left, right);

        /// <summary>
        ///     Returns a value that indicates whether a
        ///     <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> value is less than another
        ///     <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> value.
        /// </summary>
        /// <param name="left">
        ///     The first value to compare.
        /// </param>
        /// <param name="right">
        ///     The second value to compare.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> is less than <paramref name="right" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <(EnvironmentType left, EnvironmentType right) => Comparer<EnvironmentType>.Default.Compare(left, right) < 0;

        /// <summary>
        ///     Returns a value that indicates whether a
        ///     <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> value is less than or equal to another
        ///     <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> value.
        /// </summary>
        /// <param name="left">
        ///     The first value to compare.
        /// </param>
        /// <param name="right">
        ///     The second value to compare.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> is less than or equal to <paramref name="right" />;
        ///     otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <=(EnvironmentType left, EnvironmentType right) => Comparer<EnvironmentType>.Default.Compare(left, right) <= 0;

        /// <summary>
        ///     Returns a value that indicates whether the values of two
        ///     <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> objects are equal.
        /// </summary>
        /// <param name="left">
        ///     The first value to compare.
        /// </param>
        /// <param name="right">
        ///     The second value to compare.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the <paramref name="left" /> and <paramref name="right" /> parameters have
        ///     the same value; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator ==(EnvironmentType left, EnvironmentType right) => Equals(left, right);

        /// <summary>
        ///     Returns a value that indicates whether a
        ///     <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> value is greater than another
        ///     <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> value.
        /// </summary>
        /// <param name="left">
        ///     The first value to compare.
        /// </param>
        /// <param name="right">
        ///     The second value to compare.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> is greater than <paramref name="right" />;
        ///     otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator >(EnvironmentType left, EnvironmentType right) => Comparer<EnvironmentType>.Default.Compare(left, right) > 0;

        /// <summary>
        ///     Returns a value that indicates whether a
        ///     <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> value is greater than or equal to
        ///     another <see cref="OpenCollar.Extensions.Environment.EnvironmentType" /> value.
        /// </summary>
        /// <param name="left">
        ///     The first value to compare.
        /// </param>
        /// <param name="right">
        ///     The second value to compare.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> is greater than <paramref name="right" />;
        ///     otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator >=(EnvironmentType left, EnvironmentType right) => Comparer<EnvironmentType>.Default.Compare(left, right) >= 0;

        /// <summary>
        ///     Compares the current instance with another object of the same type and returns an integer that indicates
        ///     whether the current instance precedes, follows, or occurs in the same position in the sort order as the
        ///     other object.
        /// </summary>
        /// <param name="obj">
        ///     An object to compare with this instance.
        /// </param>
        /// <returns>
        ///     A value that indicates the relative order of the objects being compared. The return value has these meanings:
        ///     <list type="table">
        ///         <listheader>
        ///             <term> Value </term>
        ///             <description> Meaning </description>
        ///         </listheader>
        ///         <item>
        ///             <term> Less than zero </term>
        ///             <description> This instance precedes <paramref name="obj" /> in the sort order. </description>
        ///         </item>
        ///         <item>
        ///             <term> Zero </term>
        ///             <description> This instance occurs in the same position in the sort order as <paramref name="obj" />. </description>
        ///         </item>
        ///         <item>
        ///             <term> Greater than zero </term>
        ///             <description> This instance follows <paramref name="obj" /> in the sort order. </description>
        ///         </item>
        ///     </list>
        /// </returns>
        /// <exception cref="System.ArgumentException">
        ///     <paramref name="obj" /> is not the same type as this instance.
        /// </exception>
        public int CompareTo(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return 1;
            }

            if(ReferenceEquals(this, obj))
            {
                return 0;
            }

            return obj is EnvironmentType other ? CompareTo(other) : throw new ArgumentException(string.Format(System.Globalization.CultureInfo.InvariantCulture, OpenCollar.Extensions.Environment.Resources.Exceptions.ObjectMustBeOfType, nameof(EnvironmentType)));
        }

        /// <summary>
        ///     Compares the current instance with another object of the same type and returns an integer that indicates
        ///     whether the current instance precedes, follows, or occurs in the same position in the sort order as the
        ///     other object.
        /// </summary>
        /// <param name="other">
        ///     An object to compare with this instance.
        /// </param>
        /// <returns>
        ///     A value that indicates the relative order of the objects being compared. The return value has these meanings:
        ///     <list type="table">
        ///         <listheader>
        ///             <term> Value </term>
        ///             <description> Meaning </description>
        ///         </listheader>
        ///         <item>
        ///             <term> Less than zero </term>
        ///             <description> This instance precedes <paramref name="other" /> in the sort order. </description>
        ///         </item>
        ///         <item>
        ///             <term> Zero </term>
        ///             <description> This instance occurs in the same position in the sort order as <paramref name="other" />. </description>
        ///         </item>
        ///         <item>
        ///             <term> Greater than zero </term>
        ///             <description> This instance follows <paramref name="other" /> in the sort order. </description>
        ///         </item>
        ///     </list>
        /// </returns>
        public int CompareTo(EnvironmentType other)
        {
            if(ReferenceEquals(this, other))
            {
                return 0;
            }

            if(ReferenceEquals(null, other))
            {
                return 1;
            }

            return Sensitivity.CompareTo(other.Name);
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">
        ///     An object to compare with this object.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter;
        ///     otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(EnvironmentType other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }

            if(ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">
        ///     The object to compare with the current object.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the specified object is equal to the current object; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj is EnvironmentType other && Equals(other);

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <returns>
        ///     A hash code for the current object.
        /// </returns>
        public override int GetHashCode() => Name != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Name) : 0;

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}