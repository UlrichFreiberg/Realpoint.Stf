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
    using Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership.FractionalOwnershipContact;

    using RealpointWebTests;

    /// <summary>
    /// The test script 002.
    /// </summary>
    [TestClass]
    public class TestScript009 : RealpointTestScriptBase
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
        public void Ts009()
        {
            var contact = RealpointShell.FractionalOwnership().FractionalOwnershipContact();

            StfAssert.AreEqual("Checking that Message field is preset", "Please contact me about Fractional Ownership property in Italy", contact.Message);

            contact.Name = "Bill"; 
            contact.Send();

            var validationErrors = contact.ValidationErrorsPresent();

            StfAssert.IsTrue("Validation Errors are present", validationErrors);

            var missingFields = contact.MissingFields;

            StfAssert.IsTrue("Validation Errors are present for Email", missingFields.HasFlag(MissingRequiredFields.Email));
            //StfAssert.IsTrue("Validation Errors are present for Message", missingFields.HasFlag(MissingRequiredFields.Message));
            StfAssert.IsTrue("Validation Errors are present for Terms of use and Privacy policy", missingFields.HasFlag(MissingRequiredFields.TermsAndPrivacy));
        }
    }
}
