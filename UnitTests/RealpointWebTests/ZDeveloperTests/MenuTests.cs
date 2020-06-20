// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuTests.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the UnitTest1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.WebTests.ZDeveloperTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    using Realpoint.Stf.RealpointWeb;
    using Realpoint.Stf.RealpointWeb.Interfaces;

    using RealpointWebTests;

    /// <summary>
    /// The menu tests.
    /// </summary>
    [TestClass]
    public class MenuTests : RealpointTestScriptBase
    {
        /// <summary>
        /// The wrap track shell.
        /// </summary>
        private IRealpointWebShell realpointShell;

        /// <summary>
        /// The menu mananger.
        /// </summary>
        private MenuManager menuMananger;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            realpointShell = Get<IRealpointWebShell>();
            menuMananger = new MenuManager(realpointShell);
        }

        /// <summary>
        /// The test top menu.
        /// </summary>
        [TestMethod]
        public void TestTopMenu()
        {
            GoMenu(TopMenu.Home);
            GoMenu(TopMenu.FractionalOwnership);
            GoMenu(TopMenu.OurService);
            GoMenu(TopMenu.PropertySearch);
            GoMenu(TopMenu.DiscoverItaly);
            GoMenu(TopMenu.Rentals);
            GoMenu(TopMenu.Blog);
            GoMenu(TopMenu.Contact);

            Assert.IsFalse(false);
        }

        /// <summary>
        /// The go top menu.
        /// </summary>
        /// <param name="topMenu">
        /// The top menu.
        /// </param>
        private void GoMenu(TopMenu topMenu)
        {
            menuMananger.GoMenu(topMenu);
            StfLogger.LogScreenshot(StfLogLevel.Info, topMenu.ToString("G"));
            Sleep(2);
        }

        /// <summary>
        /// The sleep.
        /// </summary>
        /// <param name="seconds">
        /// The seconds.
        /// </param>
        private void Sleep(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }
    }
}
