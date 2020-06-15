// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertySearch.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The PropertySearch interface.
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
        /// Gets or sets a value indicating whether advanced.
        /// </summary>
        bool Advanced { get; set; }

        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
        string Keywords { get; set; }

        /// <summary>
        /// The search.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Search();
    }
}