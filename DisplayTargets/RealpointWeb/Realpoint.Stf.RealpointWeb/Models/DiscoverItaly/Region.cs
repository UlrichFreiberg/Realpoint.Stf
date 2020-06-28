// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscoverItaly.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the DiscoverItaly type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.DiscoverItaly
{
    using OpenQA.Selenium;
    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.DiscoverItaly;

    /// <summary>
    /// The discover italy.
    /// </summary>
    public class Region : RealpointWebShellModelBase, IRegion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public Region(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }

        public string Name

        {
            get
            {
                var retVal = WebAdapter.GetText(By.XPath("//h3"), 3);

                return retVal;
            }
        }
    }
}