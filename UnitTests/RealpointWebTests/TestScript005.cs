// <copyright file="TestScript005.cs" company="Mir Software">
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
    /// The TestScript005
    /// </summary>
    [TestClass]
    public class TestScript005 : RealpointTestScriptBase
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
        public void Ts005()
        {
            var propertySearch = RealpointShell.PropertySearch();

            // Can we improve this as when PropertySearch page opens it has 
            // already made a search but to get a propertySearch result object we 
            // need to call Search in the model. 
            // So we search twice
            var propertySearchResult = propertySearch.Search();

            StfLogger.LogScreenshot(StfLogLevel.Info, "After Search");

            // Open the propertysheet for a random search result 
            var propertySheet = propertySearchResult.OpenRandomSearchResult();
            StfAssert.IsNotNull("Random property sheet ", propertySheet);

            // get the message text in the property enquiry on the property sheet 
            var propertyEnquiry = propertySheet.PropertyEnquiry();
            StfAssert.IsNotNull("Property enquiry on the property sheet ", propertyEnquiry);

            var message = propertyEnquiry.Message;
            var reference = propertySheet.Reference;

            StfLogger.LogScreenshot(StfLogLevel.Info, "Property Sheet");
            StfAssert.StringContains("Property Enquiry message contains property reference", message, reference);
        }
    }
}
