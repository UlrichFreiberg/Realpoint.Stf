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
    using Realpoint.Stf.RealpointWeb.Interfaces.Blog;
    using Realpoint.Stf.RealpointWeb.Interfaces.Contact;
    using Realpoint.Stf.RealpointWeb.Interfaces.DiscoverItaly;
    using Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership;
    using Realpoint.Stf.RealpointWeb.Interfaces.Home;
    using Realpoint.Stf.RealpointWeb.Interfaces.OurService;
    using Realpoint.Stf.RealpointWeb.Interfaces.PropertySearch;
    using Realpoint.Stf.RealpointWeb.Interfaces.Rentals;
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

            StfAssert.IsInstanceOfType("Home", home, typeof(IHome));

            var fractionalOwnership = RealpointShell.FractionalOwnership();

            StfAssert.IsInstanceOfType("FractionalOwnership", fractionalOwnership, typeof(IFractionalOwnership));

            var ourService = RealpointShell.OurService();

            StfAssert.IsInstanceOfType("OurService", ourService, typeof(IOurService));

            var propertySearch = RealpointShell.PropertySearch();

            StfAssert.IsInstanceOfType("PropertySearch", propertySearch, typeof(IPropertySearch));

            var discoverItaly = RealpointShell.DiscoverItaly();

            StfAssert.IsInstanceOfType("DiscoverItaly", discoverItaly, typeof(IDiscoverItaly));

            var rentals = RealpointShell.Rentals();

            StfAssert.IsInstanceOfType("Rentals", rentals, typeof(IRentals));

            var blog = RealpointShell.Blog();

            StfAssert.IsInstanceOfType("Blog", blog, typeof(IBlog));

            var contact = RealpointShell.Contact();

            StfAssert.IsInstanceOfType("Contact", contact, typeof(IContact));
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
