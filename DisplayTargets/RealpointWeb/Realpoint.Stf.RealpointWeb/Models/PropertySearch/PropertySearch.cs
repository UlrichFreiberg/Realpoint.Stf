// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertySearch.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the PropertySearch type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.PropertySearch
{
    using OpenQA.Selenium;

    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.PropertySearch;
    using System;
    using System.Dynamic;

    /// <summary>
    /// The property search.
    /// </summary>
    public class PropertySearch : RealpointWebShellModelBase, IPropertySearch
    {
        private Random random = new Random();

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

        public IPropertySearchResult PropertySearchResult
        {
            get
            {
                var retVal = Get<IPropertySearchResult>();

                return retVal;
            }
        }

        /// <summary>
        /// The search.
        /// </summary>
        /// <returns>
        /// The <see cref="IPropertySearchResult"/>.
        /// </returns>
        public IPropertySearchResult Search()
        {
            var success = WebAdapter.ButtonClickByXpath("//button[text()='Search']");

            if (!success)
            {
                return null;
            }

            success = WebAdapter.WaitForJQueryNotActive(2);

            if (!success)
            {
                return null;
            }

            var retVal = Get<IPropertySearchResult>();

            return retVal;
        }

        /// <summary>
        /// Gets or sets a value indicating whether advanced.
        /// </summary>
        public bool Advanced
        {
            get
            {
                var retVal = WebAdapter.CheckBoxGetValueByXpath("//input[@data-fieldid='531']");

                if (!retVal)
                {
                    return false;
                }

                // When Advanced is set - some JQuery starts - need to wait for that
                retVal = WebAdapter.WaitForJQueryNotActive();

                return retVal;
            }

            set
            {
                WebAdapter.CheckBoxSetValueByXpath("//input[@data-fieldid='531']", value);
            }
        }

        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
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


        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        public string Region
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("dnn3102Region"));

                return retVal;
            }
            set
            {
                var success = WebAdapter.SelectElementSetText(By.Id("dnn3102Region"), value);
            }
        }

        /// <summary>
        /// Select a Random region
        /// </summary>
        public string SelectRandomRegion()
        {
            var listOfRegions = WebAdapter.GetText(By.Id("dnn3102Region"));

            // TODO: Check with Ulrich for these newline characters
            var lines = listOfRegions.Split( new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // TODO : Ask Ulrich how to fail fast here. 
            // This assumes that two extra entries in list ("Please select" and "All Regions")
            // How do I handle (by assert ?) if the lines.length < 2) 
            var randomRegion = lines[random.Next(2, lines.Length)];

            Region = randomRegion;

            return randomRegion;
        }
    }


}