// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScript004.cs" company="Mir Software">
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

    using RealpointWebTests;

    /// <summary>
    /// The test script 004.
    /// </summary>
    [TestClass]
    public class TestScript004 : RealpointTestScriptBase
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
        public void Ts004()
        {
            RealpointShell.MenuManager.DemoMode = true;
            RealpointShell.MenuManager.ScreenShot= true;

            var home = RealpointShell.Home();
            var fractionalOwnership = RealpointShell.FractionalOwnership();
            var ourService = RealpointShell.OurService();
            var propertySearch = RealpointShell.PropertySearch();
            var discoverItaly = RealpointShell.DiscoverItaly();
            var rentals = RealpointShell.Rentals();
            var blog = RealpointShell.Blog();
            var contact = RealpointShell.Contact();

            Assert.IsFalse(false);
        }

        /// <summary>
        /// The sleep.
        /// </summary>
        /// <param name="seconds">
        /// The seconds.
        /// </param>
        public void Sleep(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }
    }
}
