// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OurService.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the OurService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.OurService
{
    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.OurService;

    /// <summary>
    /// The our service.
    /// </summary>
    public class OurService : RealpointWebShellModelBase, IOurService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OurService"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public OurService(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }
    }
}