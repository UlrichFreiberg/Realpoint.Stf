// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertySearchResult.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IPropertySearchResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Interfaces
{
    using Realpoint.Stf.RealpointWeb.Models;

    /// <summary>
    /// The PropertySearchResult interface.
    /// </summary>
    public interface IPropertySearchResult
    {
        /// <summary>
        /// Gets a value indicating whether single search result.
        /// </summary>
        bool SingleSearchResult { get; }

        /// <summary>
        /// The open search result.
        /// </summary>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <returns>
        /// The <see cref="IPropertySheet"/>.
        /// </returns>
        IPropertySheet OpenSearchResult(int i);
    }
}