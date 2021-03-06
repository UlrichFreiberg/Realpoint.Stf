﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebAdapterFindElements.cs" company="Mir Software">
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
    using System.Collections.Generic;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.Extensions;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// The web adapter.
    /// </summary>
    public partial class WebAdapter
    {
        /// <summary>
        /// The find element.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <returns>
        /// The <see cref="IWebElement"/>.
        /// </returns>
        public IWebElement FindElement(By by)
        {
            IWebElement retVal;

            try
            {
                StfLogger.LogDebug($"Looking for FindElement [{by}]");
                retVal = WebDriver.FindElement(by);
            }
            catch (Exception ex)
            {
                // this might not be an error - if we are looking for something to become rendered in a loop....
                StfLogger.LogDebug($"Couldn't find element [{by}] - got error [{ex.Message}]");
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// The find element using an explicit wait timeout
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <param name="secondsToWait">
        /// The max number of seconds to wait.
        /// </param>
        /// <returns>
        /// The <see cref="IWebElement"/>.
        /// </returns>
        public IWebElement FindElement(By by, int secondsToWait)
        {
            IWebElement retVal;

            SetImplicitlyWait(1);
            try
            {
                var webDriverWaiter = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(secondsToWait));

                retVal = webDriverWaiter.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception ex)
            {
                // this might not be an error - if we are looking for something to become rendered in a loop....
                StfLogger.LogInternal("Couldn't find element [{0}]. Waited for [{1}] seconds - got error [{2}]", by, secondsToWait, ex.Message);
                retVal = null;
            }

            ResetImplicitlyWait();
            return retVal;
        }

        /// <summary>
        /// The find elements.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <returns>
        /// The collection of elements that matches the search term.
        /// </returns>
        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            IReadOnlyCollection<IWebElement> retVal;

            try
            {
                retVal = WebDriver.FindElements(by);
            }
            catch (Exception ex)
            {
                // this might not be an error - if we are looking for something to become rendered in a loop....
                StfLogger.LogDebug($"Couldn't find one or more elements matching [{by}] - got error [{ex.Message}]");
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// The move to element. Used to scroll to an element hidden...
        /// </summary>
        /// <param name="elem">
        /// The elem.
        /// </param>
        public void MoveToElement(IWebElement elem)
        {
            WebDriver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", elem);
        }
    }
}