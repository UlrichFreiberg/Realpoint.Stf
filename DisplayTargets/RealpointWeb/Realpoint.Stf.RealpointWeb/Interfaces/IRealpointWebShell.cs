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
    using Realpoint.Stf.RealpointWeb.Interfaces.Blog;
    using Realpoint.Stf.RealpointWeb.Interfaces.Contact;
    using Realpoint.Stf.RealpointWeb.Interfaces.DiscoverItaly;
    using Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership;
    using Realpoint.Stf.RealpointWeb.Interfaces.Home;
    using Realpoint.Stf.RealpointWeb.Interfaces.OurService;
    using Realpoint.Stf.RealpointWeb.Interfaces.PropertySearch;
    using Realpoint.Stf.RealpointWeb.Interfaces.Rentals;

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
        /// Gets the menu manager.
        /// </summary>
        MenuManager MenuManager { get; }

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

        /// <summary>
        /// The home.
        /// </summary>
        /// <returns>
        /// The <see cref="IHome"/>.
        /// </returns>
        IHome Home();

        /// <summary>
        /// The fractional ownership.
        /// </summary>
        /// <returns>
        /// The <see cref="IFractionalOwnership"/>.
        /// </returns>
        IFractionalOwnership FractionalOwnership();

        /// <summary>
        /// The our service.
        /// </summary>
        /// <returns>
        /// The <see cref="IOurService"/>.
        /// </returns>
        IOurService OurService();

        /// <summary>
        /// The discover italy.
        /// </summary>
        /// <returns>
        /// The <see cref="IDiscoverItaly"/>.
        /// </returns>
        IDiscoverItaly DiscoverItaly();

        /// <summary>
        /// The rentals.
        /// </summary>
        /// <returns>
        /// The <see cref="IRentals"/>.
        /// </returns>
        IRentals Rentals();

        /// <summary>
        /// The blog.
        /// </summary>
        /// <returns>
        /// The <see cref="IBlog"/>.
        /// </returns>
        IBlog Blog();

        /// <summary>
        /// The contact.
        /// </summary>
        /// <returns>
        /// The <see cref="IContact"/>.
        /// </returns>
        IContact Contact();
    }
}