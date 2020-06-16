// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertySheet.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the PropertySheet type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models
{
    using Realpoint.Stf.RealpointWeb.Interfaces;

    /// <summary>
    /// The property sheet.
    /// </summary>
    public class PropertySheet : RealpointWebShellModelBase, IPropertySheet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertySheet"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public PropertySheet(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }

        /// <summary>
        /// Gets the current displayed url.
        /// </summary>
        public string Url
        {
            get
            {
                var mainUrl = WebAdapter.CurrentUrl; 
                var retVal = mainUrl.Replace(RealpointWebShell.RpConfiguration.Url, string.Empty);

                return retVal;
            }
        }
    }
}