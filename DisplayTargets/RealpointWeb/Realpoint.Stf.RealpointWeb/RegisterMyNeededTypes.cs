// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterMyNeededTypes.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the RealpointWebShell type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb
{
    using Mir.Stf.Utilities;

    using Realpoint.Stf.RealpointWeb.Interfaces;

    /// <summary>
    /// The demo corp web shell.
    /// </summary>
    public class RegisterMyNeededTypes
    {
        /// <summary>
        /// The stf container used to register the types for the shell
        /// </summary>
        private readonly IStfContainer stfContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMyNeededTypes"/> class.
        /// </summary>
        /// <param name="realpointWebShell">
        /// The wt shell.
        /// </param>
        public RegisterMyNeededTypes(IRealpointWebShell realpointWebShell)
        {
            stfContainer = realpointWebShell.StfContainer;
        }

        /// <summary>
        /// The register.
        /// </summary>
        public void Register()
        {
            stfContainer.RegisterType<IPropertySearch, Models.PropertySearch>();
            stfContainer.RegisterType<IPropertySearchResult, Models.PropertySearchResult>();
            stfContainer.RegisterType<IPropertySheet, Models.PropertySheet>();
        }
    }
}
