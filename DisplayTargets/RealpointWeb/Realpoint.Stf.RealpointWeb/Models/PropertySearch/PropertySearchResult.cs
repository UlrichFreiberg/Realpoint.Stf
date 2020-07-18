// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertySearchResult.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IPropertySearchResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.PropertySearch
{
    using System;
    using System.Linq;

    using OpenQA.Selenium;

    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.PropertySearch;

    /// <summary>
    /// The property search result.
    /// </summary>
    public class PropertySearchResult : RealpointWebShellModelBase, IPropertySearchResult
    {
        private Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertySearchResult"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public PropertySearchResult(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }

        /// <summary>
        /// Gets a value indicating whether single search result.
        /// </summary>
        public bool SingleSearchResult
        {
            get
            {
                var hits = WebAdapter.FindElements(By.XPath("//div[@data-ng-repeat='item in source.data']"));

                return hits.Count == 1;
            }
        }

        /// <summary>
        /// The open search result.
        /// </summary>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <returns>
        /// The <see cref="IPropertySheet"/>.
        /// </returns>
        public IPropertySheet OpenSearchResult(int i)
        {
            var hits = WebAdapter.FindElements(By.XPath("//div[@data-ng-repeat='item in source.data']"));

            if (i > hits.Count)
            {
                StfLogger.LogInfo("requested a result that exceeds the number of results found");
                return null;
            }

            var result = hits.ElementAt(i - 1);
            var moreButton = result.FindElement(By.XPath(".//a[normalize-space() = 'More...']"));

            moreButton.Click();
            WebAdapter.WaitForJQueryNotActive();

            var retVal = Get<IPropertySheet>();

            return retVal;
        }

        /// <summary>
        /// The open random search result
        /// </summary>
        /// <returns>
        /// The <see cref="IPropertySheet"/>.
        /// </returns>
        public IPropertySheet OpenRandomSearchResult()
        {
            var hits = WebAdapter.FindElements(By.XPath("//div[@data-ng-repeat='item in source.data']"));

            if (hits.Count < 1)
            {
                return null;
            }

            var elementAt = hits.Count == 1 ? 1 : random.Next(1, hits.Count);

            return OpenSearchResult(elementAt);
        }

    }
}