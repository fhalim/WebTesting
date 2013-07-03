namespace WebTesting.Selenium
{
    using IronPython.Hosting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    public abstract class SeleniumTests
    {
        protected readonly IWebDriver Driver;

        protected SeleniumTests()
        {

            Driver = GetDriver();
        }

        public void Dispose()
        {
            Driver.Dispose();
        }

        private static IWebDriver GetDriver()
        {
            return GetDriverFromScript();
            //return GetFirefoxDriver();
        }

        private static IWebDriver GetDriverFromScript()
        {
            var pythonEngine = Python.CreateRuntime();
            pythonEngine.LoadAssembly(typeof(IWebDriver).Assembly);
            var scope = pythonEngine.ExecuteFile("seleniumconfig.py");
            return scope.GetVariable<IWebDriver>("webdriver");
        }

        private static IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver();
        }
    }
}