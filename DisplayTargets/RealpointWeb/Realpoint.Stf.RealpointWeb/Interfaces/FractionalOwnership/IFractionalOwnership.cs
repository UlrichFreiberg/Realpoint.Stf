// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFractionalOwnership.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IFractionalOwnership type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership
{
    using Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership.FractionalOwnershipContact;

    /// <summary>
    /// The FractionalOwnership interface.
    /// </summary>
    public interface IFractionalOwnership
    {

        /// <summary>
        /// The fractional ownership Contact.
        /// </summary>
        /// <returns>
        /// The <see cref="IFractionalOwnershipContact"/>.
        /// </returns>
        IFractionalOwnershipContact FractionalOwnershipContact();
    }
}