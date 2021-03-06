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
    public class DiscoverItaly : RealpointWebShellModelBase, IDiscoverItaly
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoverItaly"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public DiscoverItaly(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }

        /// <summary>
        /// Selects a region
        /// </summary>
        /// <param name="regionName">
        /// Name of region
        /// </param>
        /// <returns>
        /// Model object for a region or null if not found
        /// </returns>
        public IRegion SelectRegion(string regionName)
        {
            var success = WebAdapter.SelectElementSetText(By.Id("RPDiscoveryPageList"), regionName);

            if (! success)
            {
                return null;
            }

            success = WebAdapter.ButtonClickById("RPDiscoveryPageListButton");

            if (!success)
            {
                return null;
            }

            var retVal = Get<IRegion>();

            return retVal;
        }
    }
}