// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContact.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IContact type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Interfaces.Contact
{
    /// <summary>
    /// The Contact interface.
    /// </summary>
    public interface IContact
    {
        string Name { get; set; }

        bool Send();
    }
} 