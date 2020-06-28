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
    using Realpoint.Stf.RealpointWeb.Interfaces.Blog;
    using Realpoint.Stf.RealpointWeb.Interfaces.Contact;
    using Realpoint.Stf.RealpointWeb.Interfaces.DiscoverItaly;
    using Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership;
    using Realpoint.Stf.RealpointWeb.Interfaces.Home;
    using Realpoint.Stf.RealpointWeb.Interfaces.OurService;
    using Realpoint.Stf.RealpointWeb.Interfaces.Rentals;
    using Realpoint.Stf.RealpointWeb.Models.Blog;
    using Realpoint.Stf.RealpointWeb.Models.Contact;
    using Realpoint.Stf.RealpointWeb.Models.DiscoverItaly;
    using Realpoint.Stf.RealpointWeb.Models.FractionalOwnership;
    using Realpoint.Stf.RealpointWeb.Models.Home;
    using Realpoint.Stf.RealpointWeb.Models.OurService;
    using Realpoint.Stf.RealpointWeb.Models.Rentals;

    using Realpoint.Stf.RealpointWeb.Interfaces.FractionalOwnership.FractionalOwnershipContact;
    using Realpoint.Stf.RealpointWeb.Models.FractionalOwnership.FractionalOwnershipContact;

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
            RegisterPropertySearchClasses();
            stfContainer.RegisterType<IBlog, Blog>();
            stfContainer.RegisterType<IContact, Contact>();
            stfContainer.RegisterType<IDiscoverItaly, DiscoverItaly>();
            stfContainer.RegisterType<IFractionalOwnership, FractionalOwnership>();
            stfContainer.RegisterType<IHome, Home>();
            stfContainer.RegisterType<IOurService, OurService>();
            stfContainer.RegisterType<IRentals, Rentals>();

            stfContainer.RegisterType<IFractionalOwnershipContact, FractionalOwnershipContact>();

            stfContainer.RegisterType<IRegion, Region>();

        }

        /// <summary>
        /// The register property search classes.
        /// </summary>
        private void RegisterPropertySearchClasses()
        {
            stfContainer.RegisterType<Interfaces.PropertySearch.IPropertySearch, Models.PropertySearch.PropertySearch>();
            stfContainer.RegisterType<Interfaces.PropertySearch.IPropertySearchResult, Models.PropertySearch.PropertySearchResult>();
            stfContainer.RegisterType<Interfaces.PropertySearch.IPropertySheet, Models.PropertySearch.PropertySheet>();
        }
    }
}
