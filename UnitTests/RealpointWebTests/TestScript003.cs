// <copyright file="TestScript003.cs" company="Mir Software">
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
    /// The TestScript003
    /// </summary>
    [TestClass]
    public class TestScript003 : RealpointTestScriptBase
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
        public void Ts003()
        {
            const string selectedRegionName = "Puglia";
            var discoverItaly = RealpointShell.DiscoverItaly();
            
            StfAssert.IsNotNull("discoverItaly", discoverItaly);

            var region = discoverItaly.SelectRegion(selectedRegionName);

            StfAssert.IsNotNull("region", region);

            var regionName = region.Name;

            StfAssert.StringEqualsCi("Region is indeed the selected region", selectedRegionName, regionName);
        }
    }
}
