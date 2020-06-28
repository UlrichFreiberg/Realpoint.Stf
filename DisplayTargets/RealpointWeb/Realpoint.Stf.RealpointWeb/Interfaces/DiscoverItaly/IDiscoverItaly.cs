// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiscoverItaly.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IDiscoverItaly type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.RealpointWeb.Interfaces.DiscoverItaly
{
    /// <summary>
    /// The DiscoverItaly interface.
    /// </summary>
    public interface IDiscoverItaly
    {
        /// <summary>
        /// Selects a region
        /// </summary>
        /// <param name="regionName">
        /// Name of region
        /// </param>
        /// <returns>
        /// Model object for a region or null if not found
        /// </returns>
        IRegion SelectRegion(string regionName);
    }
}