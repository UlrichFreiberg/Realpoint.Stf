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
    using System;

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
                var xPath = GetXpathFor("Reference");
                var retVal = WebAdapter.GetText(By.XPath(xPath));

                return retVal;
            }
        }

        public string Location => GetValueForLabel("Location:");

        public string PropertyEnquiryMessage
        {
            get
            {
                var retVal = WebAdapter.GetText(By.Id("dnn2961Message"));

                return retVal;
            }
        }

        private string GetValueForLabel(string label)
        {
            var xPath = GetXpathFor(label);
            var retVal = WebAdapter.GetText(By.XPath(xPath));

            return retVal;
        }

        private string GetXpathFor(string label)
        {
            var retVal = $"//table//td[text()='{label}']/../td/span";

            return retVal;
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