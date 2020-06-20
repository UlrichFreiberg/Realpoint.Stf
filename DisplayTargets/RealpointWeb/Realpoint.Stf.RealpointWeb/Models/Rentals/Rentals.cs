// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rentals.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the Rentals type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.Rentals
{
    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.Rentals;

    /// <summary>
    /// The rentals.
    /// </summary>
    public class Rentals : RealpointWebShellModelBase, IRentals
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rentals"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public Rentals(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }
    }
}