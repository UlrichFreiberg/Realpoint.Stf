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
    using System.Collections.Generic;
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
                return Hits.Count == 1;
            }
        }

        /// <summary>
        /// The Title Label
        /// </summary>
        /// <returns>
        /// The <see cref="IPropertySheet"/>.
        /// </returns>
        public string TitleLabel
        {
            get
            {
                var retVal = WebAdapter.GetText(By.Id("dnn_ctr3483_Title_titleLabel"));

                return retVal;
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
            var hits = Hits;

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
            var hits = Hits;

            if (hits.Count < 1)
            {
                return null;
            }

            var elementAt = hits.Count == 1 ? 1 : random.Next(1, hits.Count);

            return OpenSearchResult(elementAt);
        }

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
        public bool CheckSearchResultsInSelectedRegion(string selectedRegionName)
        {
            foreach (var hit in Hits)
            {
                if (!CheckSearchResultInSelectedRegion(hit, selectedRegionName))
                {
                    StfLogger.LogFail("CheckSearchResultsInSelectedRegion", "Search result is not in selectedRegion {0}", new string[]{ selectedRegionName });
                    return false;
                }
            }

            return true;
        }

        private bool CheckSearchResultInSelectedRegion(IWebElement hit, string selectedRegionName)
        {
            var lines = hit.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length>1)
            {
                if (!lines[2].Contains(selectedRegionName))
                {
                    StfLogger.LogFail("CheckSearchResultInSelectedRegion", 
                                      "Expected region name {0} is not in expected position in summary text {1}", 
                                      new string[] { selectedRegionName, lines[2] });
                    return false;
                }
                return true;
            }
            StfLogger.LogFail("CheckSearchResultInSelectedRegion",
                              "Summary text format not as expected. {0} Expected region name in line 3",
                              new string[] { lines.ToString() });
            return false;
        }


        /// <summary>
        /// The search Hits
        /// </summary>
        /// <returns>
        /// The list of search hits
        /// </returns>
        private IReadOnlyCollection<IWebElement> Hits
        {
            get
            {
                var hits = WebAdapter.FindElements(By.XPath("//div[@data-ng-repeat='item in source.data']"));

                return hits;
            }
        }

    }
}