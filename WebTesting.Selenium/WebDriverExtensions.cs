namespace WebTesting.Selenium
{
    using System;
    using System.IO;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public static class WebDriverExtensions
    {
        public static void WaitForPageReady(this IWebDriver driver)
        {
            WaitForPageReady(driver, TimeSpan.FromSeconds(10));
        }
        public static IWebElement FindLinkByHRef(this IWebDriver driver, string url)
        {
            return driver.FindElement(By.XPath(String.Format("//a[@href='{0}']", url)));
        }
        public static void TakeScreenshot(this IWebDriver driver, string fileName)
        {
            var s = driver as ITakesScreenshot;
            if (s == null) {
                throw new InvalidOperationException("Cannot take screenshot with this browser");
            }
            var screenshot = s.GetScreenshot();
            File.WriteAllBytes(fileName, screenshot.AsByteArray);
        }
        private static void WaitForPageReady(this IWebDriver driver, TimeSpan timeout)
        {
            var js = driver as IJavaScriptExecutor;
            if (js == null) {
                throw new InvalidOperationException("Cannot execute Javascript with this browser");
            }
            new WebDriverWait(driver, timeout).Until(_ =>
            {
                var isLoadeed = (string)js.ExecuteScript("return document.readyState;");
                return isLoadeed == "complete";
            });
        }
    }
}
