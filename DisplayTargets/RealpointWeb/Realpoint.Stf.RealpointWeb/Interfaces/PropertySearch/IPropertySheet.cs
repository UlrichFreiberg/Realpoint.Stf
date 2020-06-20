// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertySheet.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IPropertySheet type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Interfaces.PropertySearch
{
    /// <summary>
    /// The PropertySheet interface.
    /// </summary>
    public interface IPropertySheet
    {
        /// <summary>
        /// Gets the current displayed url.
        /// </summary>
        string Url { get; }
    }
}