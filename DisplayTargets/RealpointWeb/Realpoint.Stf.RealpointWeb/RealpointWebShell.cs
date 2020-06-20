// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RealpointWebShell.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the RealpointWebShell type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Realpoint.Stf.RealpointWeb
{
    using OpenQA.Selenium;
    using Realpoint.Stf.Adapters.WebAdapter;
    using Realpoint.Stf.Core;
    using Realpoint.Stf.RealpointWeb.Configuration;
    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.Blog;
    using Realpoint.Stf.RealpointWeb.Interfaces.Contact;
    using Realpoint.Stf.RealpointWeb.Interfaces.DiscoverItaly;
    using Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership;
    using Realpoint.Stf.RealpointWeb.Interfaces.Home;
    using Realpoint.Stf.RealpointWeb.Interfaces.OurService;
    using Realpoint.Stf.RealpointWeb.Interfaces.PropertySearch;
    using Realpoint.Stf.RealpointWeb.Interfaces.Rentals;

    /// <summary>
    /// The demo corp web shell.
    /// </summary>
    public class RealpointWebShell : TargetBase, IRealpointWebShell
    {
        /// <summary>
        /// Backing field for the menu manager.
        /// </summary>
        private MenuManager menuManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RealpointWebShell"/> class. 
        /// </summary>
        public RealpointWebShell()
        {
            Name = "RealpointWebShell";
            VersionInfo = new Version(1, 0, 0, 0);
        }

        /// <summary>
        /// Gets or sets the wt configuration.
        /// </summary>
        public RpConfiguration RpConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the web adapter.
        /// </summary>
        public IWebAdapter WebAdapter { get; set; }

        /// <summary>
        /// Gets the menu manager.
        /// </summary>
        public MenuManager MenuManager
        {
            get
            {
                var retval = menuManager ?? (menuManager = new MenuManager(this));

                return retval;
            }
        }

        /// <summary>
        /// The text-feedback to user 
        /// </summary>
        /// <param name="infoType">
        /// The info Type.
        /// </param>
        /// <returns>
        /// True if text-feedback found
        /// </returns>
        public bool InfoText(string infoType)
        {
            try
            {
                var svar = WebAdapter.FindElement(By.Id(infoType));
                var retVal = svar != null;

                return retVal;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Logout and Close down the web adapter
        /// </summary>
        public void CloseDown()
        {
            WebAdapter.CloseDown();
        }

        /// <summary>
        /// The property search.
        /// </summary>
        /// <returns>
        /// The <see cref="IPropertySearch"/>.
        /// </returns>
        public IPropertySearch PropertySearch()
        {
            MenuManager.GoMenu(TopMenu.PropertySearch);

            var retVal = StfContainer.Get<IPropertySearch>();

            return retVal;
        }

        /// <summary>
        /// The home.
        /// </summary>
        /// <returns>
        /// The <see cref="IHome"/>.
        /// </returns>
        public IHome Home()
        {
            if (!MenuManager.GoMenu(TopMenu.Home))
            {
                return null;               
            }

            var retVal = StfContainer.Get<IHome>();

            return retVal;
        }

        /// <summary>
        /// The fractional ownership.
        /// </summary>
        /// <returns>
        /// The <see cref="IFractionalOwnership"/>.
        /// </returns>
        public IFractionalOwnership FractionalOwnership()
        {
            MenuManager.GoMenu(TopMenu.FractionalOwnership);

            var retVal = StfContainer.Get<IFractionalOwnership>();

            return retVal;
        }

        /// <summary>
        /// The our service.
        /// </summary>
        /// <returns>
        /// The <see cref="IOurService"/>.
        /// </returns>
        public IOurService OurService()
        {
            MenuManager.GoMenu(TopMenu.OurService);

            var retVal = StfContainer.Get<IOurService>();

            return retVal;
        }

        /// <summary>
        /// The discover italy.
        /// </summary>
        /// <returns>
        /// The <see cref="IDiscoverItaly"/>.
        /// </returns>
        public IDiscoverItaly DiscoverItaly()
        {
            MenuManager.GoMenu(TopMenu.DiscoverItaly);

            var retVal = StfContainer.Get<IDiscoverItaly>();

            return retVal;
        }

        /// <summary>
        /// The rentals.
        /// </summary>
        /// <returns>
        /// The <see cref="IRentals"/>.
        /// </returns>
        public IRentals Rentals()
        {
            MenuManager.GoMenu(TopMenu.Rentals);

            var retVal = StfContainer.Get<IRentals>();

            return retVal;
        }

        /// <summary>
        /// The blog.
        /// </summary>
        /// <returns>
        /// The <see cref="IBlog"/>.
        /// </returns>
        public IBlog Blog()
        {
            MenuManager.GoMenu(TopMenu.Blog);

            var retVal = StfContainer.Get<IBlog>();

            return retVal;
        }

        /// <summary>
        /// The contact.
        /// </summary>
        /// <returns>
        /// The <see cref="IContact"/>.
        /// </returns>
        public IContact Contact()
        {
            MenuManager.GoMenu(TopMenu.Contact);

            var retVal = StfContainer.Get<IContact>();

            return retVal;
        }

        /// <summary>
        /// The init.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Init()
        {
            var registerMyNeededTypes = new RegisterMyNeededTypes(this);

            registerMyNeededTypes.Register();
            RpConfiguration = SetConfig<RpConfiguration>();

            // get what I need - a WebAdapter:-)
            WebAdapter = StfContainer.Get<IWebAdapter>();

            WebAdapter.OpenUrl(RpConfiguration.Url);

            var currentDomainBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            StfLogger.LogKeyValue("Current Directory", currentDomainBaseDirectory, "Current Directory");
            return true;
        }

        /// <summary>
        /// The choose english.
        /// </summary>
        public void ChooseEnglish()
        {
            const string Xpath = @"//sprog_valg//img[@src=""http://wt.troldvaerk.org/grafik/flag/2.svg""]";

            WebAdapter.ButtonClickByXpath(Xpath);
            WebAdapter.WaitForComplete(1);
        }
    }
}
