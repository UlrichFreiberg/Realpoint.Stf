// ------------------------½--------------------------------------------------------------------------------------------
// <copyright file="RpConfiguration.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the RpConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Configuration
{
    using Mir.Stf.Utilities;

    /// <summary>
    /// The im configuration.
    /// </summary>
    public class RpConfiguration
    {
        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [StfConfiguration("DisplayTargets.RealpointWeb.BaseUrl")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the browser.
        /// </summary>
        [StfConfiguration("DisplayTargets.RealpointWeb.Browser")]
        public string Browser { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [StfConfiguration("DisplayTargets.RealpointWeb.Users.UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [StfConfiguration("DisplayTargets.RealpointWeb.Users.Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Admin user name.
        /// </summary>
        [StfConfiguration("DisplayTargets.RealpointWeb.AdminUsers.UserName")]
        public string AdminUserName { get; set; }

        /// <summary>
        /// Gets or sets the Admin password.
        /// </summary>
        [StfConfiguration("DisplayTargets.RealpointWeb.AdminUsers.Password")]
        public string AdminPassword { get; set; }
    }
}
