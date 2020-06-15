// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertySearch.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the PropertySearch type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models
{
    using OpenQA.Selenium;

    using Realpoint.Stf.RealpointWeb.Interfaces;

    /// <summary>
    /// The property search.
    /// </summary>
    public class PropertySearch : RealpointWebShellModelBase, IPropertySearch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertySearch"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public PropertySearch(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        { 
        }

        /// <summary>
        /// The search.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Search()
        {
            var retVal = WebAdapter.ButtonClickByXpath("//button[text()='Search']");
            var SyncAndWaitForResult = WebAdapter.FindElement(By.XPath("//h1/span[text()=''Property For Sale In Italy]"), 10);

            return retVal;
        }

        public bool Advanced
        {
            get
            {
                var retVal = WebAdapter.CheckBoxGetValueByXpath("//label[text()='Advanced Search']/../Input");

                return retVal;
            }

            set
            {
                WebAdapter.CheckBoxSetValueByXpath("//input[@data-fieldid='531']", value);
            }
        }

        public string Keywords
        {
            get
            {
                var elem = WebAdapter.FindElement(By.XPath("//input[@data-fieldid='262']"));
                var retVal = elem?.Text;

                return retVal;
            }

            set
            {
                WebAdapter.TextboxSetTextByXpath("//input[@data-fieldid='262']", value);
            }
        }
    }
}