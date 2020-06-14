// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RealpointTestScriptBase.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the RealpointTestScriptBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RealpointWebTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;
    using Realpoint.Stf.RealpointWeb.Interfaces;

    /// <summary>
    /// The wrap track test script base.
    /// </summary>
    public abstract class RealpointTestScriptBase : StfTestScriptBase
    {
        /// <summary>
        /// Gets or sets the wrap track shell.
        /// </summary>
        protected IRealpointWebShell RealpointShell { get; set; }

        /// <summary>
        /// The test cleanup.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            // ensure to logout and to close down the web adapter
            RealpointShell?.CloseDown();
        }

        /// <summary>
        /// Function used to wait a period of time.
        /// </summary>
        /// <param name="duration">
        /// The duration.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected bool Wait(TimeSpan duration)
        {
            System.Threading.Thread.Sleep(duration);

            return true;
        }
    }
}
