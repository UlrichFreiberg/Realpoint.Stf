// <copyright file="TestScript001.cs" company="Mir Software">
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
    /// The TestScript001
    /// </summary>
    [TestClass]
    public class TestScript001 : RealpointTestScriptBase
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
        /// The test clean up.
        /// </summary>
        [TestCleanup]
        public void TestCleanUp()
        {
            RealpointShell?.CloseDown();
        }

        [TestMethod]
        public void Ts001()
        {
            StfAssert.IsNotNull("RealpointShell", RealpointShell);

            var propertySearch = RealpointShell.PropertySearch();

            propertySearch.Advanced = true;
            propertySearch.Keywords = "CE324";

            var result = propertySearch.Search();

            StfAssert.IsTrue("Search succeeded", result);
            StfLogger.LogScreenshot(StfLogLevel.Info, "After Search");
        }
    }
}
