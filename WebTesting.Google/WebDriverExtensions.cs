
namespace WebTesting.Google
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    static class WebDriverExtensions
    {
        public static void WaitForPageReady(this IWebDriver driver)
        {
            WaitForPageReady(driver, TimeSpan.FromSeconds(10));
        }
        private static void WaitForPageReady(this IWebDriver driver, TimeSpan timeout)
        {
            var js = driver as IJavaScriptExecutor;
            new WebDriverWait(driver, timeout).Until(_ =>
            {
                var isLoadeed = (string)js.ExecuteScript("return document.readyState;");
                return isLoadeed == "complete";
            });
        }
    }
}
