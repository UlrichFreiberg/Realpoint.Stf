// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the Contact type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Models.Contact
{
    using System.Text.RegularExpressions;

    using OpenQA.Selenium;
    using Realpoint.Stf.RealpointWeb.Interfaces;
    using Realpoint.Stf.RealpointWeb.Interfaces.Contact;

    /// <summary>
    /// The contact.
    /// </summary>
    public class Contact : RealpointWebShellModelBase, IContact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The realpoint web shell.
        /// </param>
        public Contact(IRealpointWebShell realpointWebShell)
            : base(realpointWebShell)
        {
        }

        /// <summary>
        /// Gets the missing fields.
        /// </summary>
        public MissingRequiredFields MissingFields
        {
            get
            {
                var validationErrorElems = WebAdapter.FindElements(By.XPath("//span[normalize-space()='This field is required.']"));

                if (validationErrorElems.Count == 0)
                {
                    return MissingRequiredFields.None;
                }

                var retVal = MissingRequiredFields.None;

                foreach (var validationErrorElem in validationErrorElems)
                {
                    if (validationErrorElem.Displayed)
                    {
                        var forText = validationErrorElem.GetAttribute("for");
                        var fieldIndication = Regex.Replace(forText, @"^dnn[\d]+", string.Empty);
                        var field = GetFieldForIndication(fieldIndication);

                        retVal |= field;
                    }
                }

                return retVal;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                var retVal = WebAdapter.GetText(By.Id("dnn2964Name"));

                return retVal;
            }

            set
            {
                WebAdapter.TextboxSetTextById("dnn2964Name", value);
            }
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Send()
        {
            var retVal = WebAdapter.ButtonClickById("dnn2964Send");

            return retVal;
        }

        /// <summary>
        /// The validation errors present.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ValidationErrorsPresent()
        {
            var retVal = MissingFields != MissingRequiredFields.None;

            return retVal;
        }

        /// <summary>
        /// The get field for indication.
        /// </summary>
        /// <param name="fieldIndication">
        /// The field indication.
        /// </param>
        /// <returns>
        /// The <see cref="MissingRequiredFields"/>.
        /// </returns>
        private MissingRequiredFields GetFieldForIndication(string fieldIndication)
        {
            switch (fieldIndication.ToLower())
            {
                case "name":
                    return MissingRequiredFields.Name;
                case "email":
                    return MissingRequiredFields.Email;
                case "message":
                    return MissingRequiredFields.Message;
                case "agreetandc":
                    return MissingRequiredFields.TermsAndPrivacy;
                default:
                    return MissingRequiredFields.Unknown;
            }
        }
    }
}