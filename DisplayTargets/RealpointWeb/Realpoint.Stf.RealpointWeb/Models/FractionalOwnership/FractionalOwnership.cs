// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FractionalOwnership.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the FractionalOwnership type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.FractionalOwnership
{
    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership;

    /// <summary>
    /// The fractional ownership.
    /// </summary>
    public class FractionalOwnership : RealpointWebShellModelBase, IFractionalOwnership
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FractionalOwnership"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public FractionalOwnership(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }
    }
}