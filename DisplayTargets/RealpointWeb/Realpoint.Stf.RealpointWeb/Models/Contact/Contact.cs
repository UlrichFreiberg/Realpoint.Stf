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

        public bool Send()
        {
            var retVal = WebAdapter.ButtonClickById("dnn2964Send");

            return retVal;
        }
    }
}