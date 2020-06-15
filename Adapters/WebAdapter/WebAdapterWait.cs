// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebAdapterWait.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WebAdapter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Realpoint.Stf.Adapters.WebAdapter
{
    using System;
    using System.Threading;

    using OpenQA.Selenium;

    /// <summary>
    /// The web adapter.
    /// </summary>
    public partial class WebAdapter
    {
        /// <summary>
        /// The set implicitly wait.
        /// </summary>
        /// <param name="seconds">
        /// The seconds.
        /// </param>
        public void SetImplicitlyWait(int seconds)
        {
            if (seconds == -1)
            {
                seconds = Configuration.WaitForControlReadyTimeout;
            }

            // read more here: http://docs.seleniumhq.org/docs/04_webdriver_advanced.jsp
            SetImplicitlyWait(TimeSpan.FromSeconds(double.Parse(seconds.ToString())));
        }

        /// <summary>
        /// The set implicitly wait.
        /// </summary>
        /// <param name="timeSpan">
        /// The time span.
        /// </param>
        public void SetImplicitlyWait(TimeSpan timeSpan)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = timeSpan;
        }

        /// <summary>
        /// The reset implicitly wait. Sets the value according to the configuration
        /// </summary>
        public void ResetImplicitlyWait()
        {
            SetImplicitlyWait(-1);
        }

        /// <summary>
        /// The wait for complete.
        /// </summary>
        /// <param name="seconds">
        /// The seconds.
        /// </param>
        public void WaitForComplete(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        /// <summary>
        /// Overload for The wait for complete.
        /// </summary>
        /// <param name="timeSpan">
        /// The time span.
        /// </param>
        public void WaitForComplete(TimeSpan timeSpan)
        {
            WaitForComplete((int)timeSpan.TotalSeconds);
        }

        /// <summary>
        /// The wait for j query active.
        /// </summary>
        /// <param name="secondsToWaitForPageToRender">
        /// The seconds To Wait For Page To Render after JQuery is done.
        /// </param>
        /// <returns>
        /// Indication of success
        /// </returns>
        public bool WaitForJQueryNotActive(int secondsToWaitForPageToRender = 1)
        {
            while ((bool)((IJavaScriptExecutor)WebDriver).ExecuteScript("return (window.jQuery != null) && (jQuery.active !== 0);"))
            {
                WaitForComplete(TimeSpan.FromMilliseconds(200));

                // TODO: something timeout and then return false
            }

            WaitForComplete(TimeSpan.FromSeconds(secondsToWaitForPageToRender));

            return true;
        }
    }
}