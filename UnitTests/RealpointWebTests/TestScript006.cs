// <copyright file="TestScript006.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the TestScript001 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Realpoint.Stf.RealpointWeb.Interfaces;
using RealpointWebTests;

namespace Realpoint.Stf.WebTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    /// <summary>
    /// The TestScript006
    /// </summary>
    [TestClass]
    public class TestScript006 : RealpointTestScriptBase
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
        public void Ts006()
        {
            const string selectedRegionName = "Calabria";
            var propertySearch = RealpointShell.PropertySearch();

            propertySearch.Region = selectedRegionName;
            propertySearch.Search();

            var propertySearchResult = propertySearch.PropertySearchResult;

            StfLogger.LogScreenshot(StfLogLevel.Info, "After Search");

            var titleLabel = propertySearchResult.TitleLabel;

            StfAssert.StringContains("Title Label contains ", titleLabel, selectedRegionName);
        }
    }
}
