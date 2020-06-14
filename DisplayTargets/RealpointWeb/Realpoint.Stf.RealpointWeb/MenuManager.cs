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
    using OpenQA.Selenium;

    using Adapters.WebAdapter;

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
        /// <param name="webAdapter">
        /// The web adapter.
        /// </param>
        public MenuManager(IWebAdapter webAdapter)
        {
            WebAdapter = webAdapter;
        }

        /// <summary>
        /// Gets the web adapter.
        /// </summary>
        private IWebAdapter WebAdapter { get; }

        /// <summary>
        /// The go menu.
        /// </summary>
        /// <param name="topMen">
        /// The top men.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GoMenu(TopMenu topMen)
        {
            bool retVal;

            switch (topMen)
            {
                case TopMenu.Home:
                    retVal = PressMenu("Home");
                    break;
                case TopMenu.Blog:
                    retVal = PressMenu("Blog");
                    break;
                case TopMenu.Contact:
                    retVal = PressMenu("Contact");
                    break;
                case TopMenu.DiscoverItaly:
                    retVal = PressMenu("Discover Italy");
                    break;
                case TopMenu.FractionalOwnership:
                    retVal = PressMenu("Fractional Ownership");
                    break;
                case TopMenu.OurService:
                    retVal = PressMenu("Our Service");
                    break;
                case TopMenu.Rentals:
                    retVal = PressMenu("Rentals");
                    break;
                case TopMenu.PropertySearch:
                    retVal = PressMenu("Property Search");
                    break;
                default:
                    retVal = false;
                    break;
            }

            return retVal;
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

            return true;
        }
    }
}
