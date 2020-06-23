// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContact.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IContact type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership.FractionalOwnershipContact
{
    using System;

    /// <summary>
    /// Enum to describe missing Required Fields
    /// </summary>
    [Flags]
    public enum MissingRequiredFields
    {
        /// <summary>
        /// The none.
        /// </summary>
        None = 0,

        /// <summary>
        /// The name.
        /// </summary>
        Name = 1 << 0,

        /// <summary>
        /// The email.
        /// </summary>
        Email = 1 << 1,

        /// <summary>
        /// The message.
        /// </summary>
        Message = 1 << 2,

        /// <summary>
        /// The terms and privacy.
        /// </summary>
        TermsAndPrivacy = 1 << 3,

        /// <summary>
        /// The unknown - used for parsing errors, and error return value
        /// </summary>
        Unknown = 1 << 4
    }

    /// <summary>
    /// The Contact interface.
    /// </summary>
    public interface IFractionalOwnershipContact
    {
        /// <summary>
        /// Gets the missing fields.
        /// </summary>
        MissingRequiredFields MissingFields { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// The send.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Send();

        /// <summary>
        /// The validation errors present.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool ValidationErrorsPresent();
    }
} 