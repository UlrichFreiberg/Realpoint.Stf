// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchTest.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The menu tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.WebTests.ZDeveloperTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    using Realpoint.Stf.RealpointWeb.Interfaces;

    using RealpointWebTests;

    /// <summary>
    /// The menu tests.
    /// </summary>
    [TestClass]
    public class SearchTest : RealpointTestScriptBase
    {
        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            RealpointShell = Get<IRealpointWebShell>();
        }

        /// <summary>
        /// The test top menu.
        /// </summary>
        [TestMethod]
        public void TestSearch()
        {
            var propertySearch = RealpointShell.PropertySearch();
            var propertySearchResult = propertySearch.Search();

            StfAssert.IsTrue("Found more than one property", !propertySearchResult.SingleSearchResult);
            StfLogger.LogScreenshot(StfLogLevel.Info, "After Search");
        }
    }
}
