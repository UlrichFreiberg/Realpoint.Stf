// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRealpointWebShell.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IRealpointWebShell type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Interfaces
{
    using Adapters.WebAdapter;
    using Mir.Stf.Utilities;
    using Mir.Stf.Utilities.Attributes;

    using Realpoint.Stf.RealpointWeb.Configuration;

    /// <summary>
    /// The RealpointWebShell interface.
    /// </summary>
    [StfSingleton]
    public interface IRealpointWebShell : IStfPlugin
    {
        /// <summary>
        /// Gets or sets the wt configuration.
        /// </summary>
        RpConfiguration RpConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the web adapter.
        /// </summary>
        IWebAdapter WebAdapter { get; set; }

        /// <summary>
        /// Checks if feedback for user is shown
        /// </summary>
        /// <param name="v">
        /// The v.
        /// </param>
        /// <returns>
        /// 1: info element found
        /// </returns>
        bool InfoText(string v);

        /// <summary>
        /// Logout and Close down the web adapter
        /// </summary>
        void CloseDown();

        /// <summary>
        /// The property search.
        /// </summary>
        /// <returns>
        /// The <see cref="IPropertySearch"/>.
        /// </returns>
        IPropertySearch PropertySearch();
    }
}