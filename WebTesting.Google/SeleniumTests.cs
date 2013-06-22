namespace WebTesting.Google
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    public abstract class SeleniumTests
    {
        protected readonly IWebDriver Driver;

        public SeleniumTests()
        {
            Driver = GetDriver();
        }

        public void Dispose()
        {
            Driver.Dispose();
        }

        private static IWebDriver GetDriver()
        {
            return GetFirefoxDriver();
        }

        private static IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver();
        }
    }
}