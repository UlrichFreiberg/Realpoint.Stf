// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuManager.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MenuManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb
{
    using System;

    using OpenQA.Selenium;

    using Adapters.WebAdapter;

    using Mir.Stf.Utilities;
    using Mir.Stf.Utilities.Interfaces;

    using Realpoint.Stf.RealpointWeb.Interfaces;

    /// <summary>
    /// The top menu.
    /// </summary>
    public enum TopMenu
    {
        /// <summary>
        /// The home.
        /// </summary>
        Home,

        /// <summary>
        /// The Fractional Ownership
        /// </summary>
        FractionalOwnership,

        /// <summary>
        /// The Our Service
        /// </summary>
        OurService,

        /// <summary>
        /// The Property Search
        /// </summary>
        PropertySearch,

        /// <summary>
        /// The Discover Italy
        /// </summary>
        DiscoverItaly,

        /// <summary>
        /// The Rentals
        /// </summary>
        Rentals,

        /// <summary>
        /// The Blog
        /// </summary>
        Blog,

        /// <summary>
        /// The Contacts
        /// </summary>
        Contact
    }

    /// <summary>
    /// The menu manager.
    /// </summary>
    public class MenuManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuManager"/> class.
        /// </summary>
        public MenuManager(IRealpointWebShell realpointWebShell)
        {
            WebAdapter = realpointWebShell.WebAdapter;
            StfLogger = realpointWebShell.StfLogger;
            DemoMode = ScreenShot = false;
        }

        private IStfLogger StfLogger { get; }

        /// <summary>
        /// Gets the web adapter.
        /// </summary>
        private IWebAdapter WebAdapter { get; }

        /// <summary>
        /// Gets or sets whether or not to sleep after menu selection - allowing a demo  
        /// </summary>
        public bool DemoMode { get; set; }

        /// <summary>
        /// Sets or gets whether or not to take a screen shot after each menu selection
        /// </summary>
        public bool ScreenShot { get; set; }

        /// <summary>
        /// The go menu.
        /// </summary>
        /// <param name="topMenu">
        /// The top men.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GoMenu(TopMenu topMenu)
        {
            bool retVal;

            switch (topMenu)
            {
                case TopMenu.Home:
                    retVal = GoAndCheckHome();
                    break;
                case TopMenu.Blog:
                    retVal = GoAndCheckBlog();
                    break;
                case TopMenu.Contact:
                    retVal = GoAndCheckContact();
                    break;
                case TopMenu.DiscoverItaly:
                    retVal = GoAndCheckDiscoverItaly();
                    break;
                case TopMenu.FractionalOwnership:
                    retVal = GoAndCheckFractionalOwnership();
                    break;
                case TopMenu.OurService:
                    retVal = GoAndCheckOurService();
                    break;
                case TopMenu.Rentals:
                    retVal = GoAndCheckRentals();
                    break;
                case TopMenu.PropertySearch:
                    retVal = GoAndCheckPropertySearch();
                    break;
                default:
                    retVal = false;
                    break;
            }

            if (ScreenShot)
            {
                StfLogger.LogScreenshot(StfLogLevel.Info, topMenu.ToString("G"));
            }

            if (DemoMode)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
            }

            return retVal;
        }

        private bool GoAndCheckPropertySearch()
        {
            var retVal = PressMenu("Property Search");

            if (!retVal)
            {
                return false;
            }

            // TODO some checks for we really are one this page
            // Check the H1 title
            var titleElem = WebAdapter.FindElement(By.XPath("//div[@class='TitleTitle']/h1/span[normalize-space()='Property for sale in Sicily, Italy']"));

            retVal = titleElem != null;
            return retVal;
        }

        private bool GoAndCheckRentals()
        {
            var retVal = PressMenu("Rentals");

            if (!retVal)
            {
                return false;
            }

            // TODO some checks for we really are one this page
            return true;
        }

        private bool GoAndCheckOurService()
        {
            var retVal = PressMenu("Our Service");

            if (!retVal)
            {
                return false;
            }

            // TODO some checks for we really are one this page
            return true;
        }

        private bool GoAndCheckFractionalOwnership()
        {
            var retVal = PressMenu("Fractional Ownership");

            if (!retVal)
            {
                return false;
            }

            // TODO some checks for we really are one this page
            return true;
        }

        private bool GoAndCheckDiscoverItaly()
        {
            var retVal = PressMenu("Discover Italy");

            if (!retVal)
            {
                return false;
            }

            // TODO some checks for we really are one this page
            return true;
        }

        private bool GoAndCheckContact()
        {
            var retVal = PressMenu("Contact");

            if (!retVal)
            {
                return false;
            }

            // TODO some checks for we really are one this page
            return true;
        }

        private bool GoAndCheckBlog()
        {
            var retVal = PressMenu("Blog");

            if (!retVal)
            {
                return false;
            }

            // TODO some checks for we really are one this page
            return true;
        }

        private bool GoAndCheckHome()
        {
            var retVal = PressMenu("Home");

            if (!retVal)
            {
                return false;
            }

            // TODO some checks for we really are one this page
            return true;
        }

        /// <summary>
        /// The press top menu.
        /// </summary>
        /// <param name="menuName">
        /// The menu name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool PressMenu(string menuName)
        {
            var xpath = $"//div[normalize-space()='{menuName}']";
            var element = WebAdapter.FindElement(By.XPath(xpath));

            if (element == null)
            {
                return false;
            }

            element.Click();

            // wait for spinners to terminate
            WebAdapter.WaitForJQueryNotActive();

            return true;
        }
    }
}
