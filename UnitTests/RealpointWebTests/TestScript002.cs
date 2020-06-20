// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScript002.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the UnitTest1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.WebTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.Contact;

    using RealpointWebTests;

    /// <summary>
    /// The test script 002.
    /// </summary>
    [TestClass]
    public class TestScript002 : RealpointTestScriptBase
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
        /// The test script 002
        /// </summary>
        [TestMethod]
        public void Ts002()
        {
            var contact = RealpointShell.Contact();

            contact.Name = "Fred"; 
            contact.Send();

            var validationErrors = contact.ValidationErrorsPresent();

            StfAssert.IsTrue("Validation Errors are present", validationErrors);

            var missingFields = contact.MissingFields;

            StfAssert.IsTrue("Validation Errors are present for Email", missingFields.HasFlag(MissingRequiredFields.Email));
            StfAssert.IsTrue("Validation Errors are present for Message", missingFields.HasFlag(MissingRequiredFields.Message));
        }
    }
}
