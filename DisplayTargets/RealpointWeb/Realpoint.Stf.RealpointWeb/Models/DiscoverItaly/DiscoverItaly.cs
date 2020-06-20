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
    }
}