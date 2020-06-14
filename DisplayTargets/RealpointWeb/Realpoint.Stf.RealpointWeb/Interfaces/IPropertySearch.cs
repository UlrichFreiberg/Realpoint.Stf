// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertySearch.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IPropertySearch type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Interfaces
{
    /// <summary>
    /// The PropertySearch interface.
    /// </summary>
    public interface IPropertySearch
    {
        /// <summary>
        /// The search.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Search();
    }
}