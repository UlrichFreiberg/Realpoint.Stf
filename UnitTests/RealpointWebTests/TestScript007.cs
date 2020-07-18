// <copyright file="TestScript007.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the TestScript007 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Realpoint.Stf.RealpointWeb.Interfaces;
using RealpointWebTests;

namespace Realpoint.Stf.WebTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    /// <summary>
    /// The TestScript007
    /// </summary>
    [TestClass]
    public class TestScript007 : RealpointTestScriptBase
    {
        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            RealpointShell = Get<IRealpointWebShell>();
            StfAssert.IsNotNull("RealpointShell", RealpointShell);
        }

        /// <summary>
        /// The test clean up.
        /// </summary>
        [TestCleanup]
        public void TestCleanUp()
        {
            RealpointShell?.CloseDown();
        }

        [TestMethod]
        public void Ts007()
        {
            var propertySearch = RealpointShell.PropertySearch();

            StfAssert.IsNotNull("propertySearch", propertySearch);

            var selectedRegionName = propertySearch.SelectRandomRegion();

            propertySearch.Search();

            var propertySearchResult = propertySearch.PropertySearchResult;

            StfAssert.IsNotNull("propertySearchResult", propertySearchResult);

            StfLogger.LogScreenshot(StfLogLevel.Info, "After Search");

            // TODO : Ulrich 
            // Couldn't decide how to do this 
            // I wantyed to create a method in the search results class to loop through the hits and 
            // check that each hits was in the correct region 
            // But then couldnt find out how to assert in the model classes 
            // propertySearchResult.CheckSearchResultsInSelectedRegion(selectedRegionName);
            // So I have just called stflogger.failed in propertySearchResult.CheckSearchResultsInSelectedRegion

            var searchResultsInSelectedRegion = propertySearchResult.CheckSearchResultsInSelectedRegion(selectedRegionName);

            StfAssert.IsTrue("searchResultsInSelectedRegion", searchResultsInSelectedRegion);

            /**
            var titleLabel = propertySearchResult.TitleLabel;

            StfAssert.StringContains("Title Label contains ", titleLabel, selectedRegionName);
            */
        }
    }
}
