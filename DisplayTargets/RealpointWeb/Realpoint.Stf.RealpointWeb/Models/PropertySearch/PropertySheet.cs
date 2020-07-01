// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertySheet.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the PropertySheet type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.PropertySearch
{
    using Mir.Stf.Utilities;
    using OpenQA.Selenium;
    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.PropertySearch;

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

        /// <summary>
        /// Gets the reference.
        /// </summary>

        public string Reference
        {
            get
            {
                // TODO: improve getting the element by Xpath. I wanted to serach for TD where text was Reference and then get the next td contents 
                // see PropertySheet page
                // I feel also we should here assert if the elem is null 
                // i just cant get StfAsset here ... how do I do that ? 
                var elem = WebAdapter.FindElement(By.XPath("//table[@class='table table-bordered table-condensed']/tbody//tr[1]/td[2]/span"));                
                var retVal = elem?.Text;

                return retVal;
            }
        }

        /// <summary>
        /// The Property Enquiry
        /// </summary>
        /// <returns>
        /// The <see cref="IPropertyEnquiry"/>.
        /// </returns>
        public IPropertyEnquiry PropertyEnquiry()
        {
            var retVal = Get<IPropertyEnquiry>();

            return retVal;
        }
    }
}