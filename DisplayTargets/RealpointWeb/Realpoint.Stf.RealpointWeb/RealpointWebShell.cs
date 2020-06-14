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

    /// <summary>
    /// The demo corp web shell.
    /// </summary>
    public class RealpointWebShell : TargetBase, IRealpointWebShell
    {
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
            var bob = new MenuManager(WebAdapter);

            bob.GoMenu(TopMenu.PropertySearch);

            var retVal = StfContainer.Get<IPropertySearch>();

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
        private void ChooseEnglish()
        {
            const string Xpath = @"//sprog_valg//img[@src=""http://wt.troldvaerk.org/grafik/flag/2.svg""]";

            WebAdapter.ButtonClickByXpath(Xpath);
            WebAdapter.WaitForComplete(1);
        }
    }
}
