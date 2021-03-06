// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Home.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the Home type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.Home
{
    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.Home;

    /// <summary>
    /// The home.
    /// </summary>
    public class Home : RealpointWebShellModelBase, IHome
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Home"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public Home(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }
    }
}