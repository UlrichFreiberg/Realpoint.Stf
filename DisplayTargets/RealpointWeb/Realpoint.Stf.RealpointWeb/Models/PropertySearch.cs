// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertySearch.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the PropertySearch type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models
{
    using Realpoint.Stf.RealpointWeb.Interfaces;

    /// <summary>
    /// The property search.
    /// </summary>
    public class PropertySearch : RealpointWebShellModelBase, IPropertySearch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertySearch"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public PropertySearch(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        { 
        }

        /// <summary>
        /// The search.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Search()
        {
            var retVal = WebAdapter.ButtonClickByXpath("//button[text()='Search']");

            return retVal;
        }
    }
}