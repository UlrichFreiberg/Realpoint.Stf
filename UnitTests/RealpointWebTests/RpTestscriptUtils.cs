// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RpTestscriptUtils.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the RpTestscriptUtils type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RealpointWebTests
{
    using System;

    using Mir.Stf.Utilities.Interfaces;

    /// <summary>
    /// The util.
    /// </summary>
    public class RpTestscriptUtils
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RpTestscriptUtils"/> class.
        /// </summary>
        /// <param name="stfLogger">
        /// The stf logger.
        /// </param>
        public RpTestscriptUtils(IStfLogger stfLogger)
        {
            StfLogger = stfLogger;
        }

        /// <summary>
        /// Gets or sets the stf logger.
        /// </summary>
        public IStfLogger StfLogger { get; set; }

        /// <summary>
        /// The date plus days.
        /// </summary>
        /// <param name="days">
        /// The days.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// </returns>
        public static string TodayPlusDays(int days, string format = "yyyyMMdd")
        {
            var date = DateTime.Today + TimeSpan.FromDays(days);
            var retVal = date.ToString(format);

            return retVal;
        }
    }
}
