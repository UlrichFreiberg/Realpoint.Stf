﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertySearchResult.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IPropertySearchResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Interfaces.PropertySearch
{
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
        /// The Title label
        /// </summary>
        string TitleLabel { get; }

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

        /// <summary>
        /// The open random search result.
        /// </summary>
        /// <returns>
        /// The <see cref="IPropertySheet"/>.
        /// </returns>
        IPropertySheet OpenRandomSearchResult();

        /// <summary>
        /// The implementation for checking if the peoperties in the search 
        /// result are in the selected region
        /// </summary>
        /// <param name="selectedRegionName">
        /// The selected region
        /// </param>
        /// <returns>
        /// The result, false if .
        /// </returns>
        bool CheckSearchResultsInSelectedRegion(string selectedRegionName);
    }
}