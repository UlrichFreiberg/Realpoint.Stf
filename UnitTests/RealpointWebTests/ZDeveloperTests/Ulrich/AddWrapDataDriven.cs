// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddWrapDataDriven.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the UnitTest1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RealpointWebTests.ZDeveloperTests.Ulrich
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.Me.Collection.CarrierManagement;

    /// <summary>
    /// The menu tests.
    /// </summary>
    [TestClass]
    public class AddWrapDataDriven : RealpointTestScriptBase
    {
        /// <summary>
        /// The add woven.
        /// </summary>
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"D:\Projects\Realpoint.Stf\TestData\Testdata_add_woven_wrap.csv",
            "Testdata_add_woven_wrap#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void AddWoven()
        {
            var testdata = InitTestData<WovenTestData>();
            var realpointWebShell = Get<IRealpointWebShell>();

            // Use default user
            realpointWebShell.Login();

            var me = realpointWebShell.Me();
            var collection = me.GetCollection();
            var addCarrier = collection.AddCarrier<IWowenWrap>();

            StfAssert.IsTrue("HandleHomeMade", HandleHomeMade(addCarrier, testdata));
            StfAssert.IsTrue("HandleBrandPatternModel", HandleBrandPatternModel(addCarrier, testdata));
            StfAssert.IsTrue("HandleSizeGradeAcquired", HandleSizeGradeAcquired(addCarrier, testdata));
            StfAssert.IsTrue("Save", addCarrier.Save(testdata.Brand));

            // Log where we got redirected to - Page Safe is fine - Control is better:-)
            StfLogger.LogScreenshot(StfLogLevel.SubHeader, "After Pressed Save");
            realpointWebShell.CloseDown();
        }

        /// <summary>
        /// The handle home made.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="testdata">
        /// The testdata.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HandleHomeMade(IWowenWrap addCarrier, WovenTestData testdata)
        {
            if (string.IsNullOrEmpty(testdata.HomeMade))
            {
                addCarrier.HomeMade = false;

                return true;
            }

            addCarrier.HomeMade = true;
            addCarrier.Name = $"MyOwn_{Guid.NewGuid()}";

            return true;
        }

        /// <summary>
        /// The brand pattern model.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="testdata">
        /// The testdata.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HandleBrandPatternModel(IWowenWrap addCarrier, WovenTestData testdata)
        {
            if (!string.IsNullOrEmpty(testdata.Brand))
            {
                addCarrier.Brand = testdata.Brand;
            }

            addCarrier.Pattern = string.IsNullOrEmpty(testdata.Pattern) 
                               ? "--- without pattern ---"
                               : testdata.Pattern;

            if (!string.IsNullOrEmpty(testdata.Model))
            {
                addCarrier.Model = testdata.Model;
            }

            return true;
        }

        /// <summary>
        /// The handle size grade acquired.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="testdata">
        /// The testdata.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HandleSizeGradeAcquired(IWowenWrap addCarrier, WovenTestData testdata)
        {
            addCarrier.Size = testdata.Size;
            addCarrier.Grade = testdata.Grade;

            int daysOffSet;

            if (!int.TryParse(testdata.Acquired, out daysOffSet))
            {
                daysOffSet = 0;
            }

            var acquired = DateTime.Now.AddDays(daysOffSet);

            addCarrier.Acquired = acquired;

            return true;
        }
    }
}
