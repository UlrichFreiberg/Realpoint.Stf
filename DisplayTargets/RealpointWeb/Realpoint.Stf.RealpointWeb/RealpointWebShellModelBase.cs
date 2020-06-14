// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RealpointWebShellModelBase.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The im shell model base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb
{
    using Mir.Stf.Utilities;

    using Realpoint.Stf.Adapters.WebAdapter;
    using Realpoint.Stf.RealpointWeb.Interfaces;

    /// <summary>
    /// The im shell model base.
    /// </summary>
    public abstract class RealpointWebShellModelBase : StfModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RealpointWebShellModelBase"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The wrap track web shell.
        /// </param>
        protected RealpointWebShellModelBase(IRealpointWebShell realpointWebShell)
        {
            RealpointWebShell = realpointWebShell;
            WebAdapter = realpointWebShell.WebAdapter;
        }

        /// <summary>
        /// Gets or sets the wrap track web shell.
        /// </summary>
        protected IRealpointWebShell RealpointWebShell { get; set; }

        /// <summary>
        /// Gets or sets the web adapter.
        /// </summary>
        protected IWebAdapter WebAdapter { get; set; }
    }
}