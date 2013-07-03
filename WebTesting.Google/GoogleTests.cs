namespace WebTesting.Google
{
    using OpenQA.Selenium;
    using Selenium;
    using Xunit;

    public class GoogleTests : SeleniumTests
    {
        [Fact]
        public void TestHomePageAppears()
        {
            GoToGoogleCom();
            EnterMicrosoftAsSearchText();
            Search();
            VerifyLinkToMicrosoft();
            //Driver.TakeScreenshot("microsoft_screenshot.png");
        }

        private void VerifyLinkToMicrosoft()
        {
            var microsoftComLink = Driver.FindLinkByHRef("http://www.microsoft.com/");
            Assert.NotNull(microsoftComLink);
        }

        private void Search()
        {
            var searchButton = Driver.FindElement(By.Name("btnG"));
            Assert.Equal("button", searchButton.TagName);
            searchButton.Click();
            Driver.WaitForPageReady();
        }

        private void EnterMicrosoftAsSearchText()
        {
            var searchbox = Driver.FindElement(By.Name("q"));
            Assert.NotNull(searchbox);
            searchbox.Click();
            searchbox.SendKeys("microsoft");
        }

        private void GoToGoogleCom()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");
        }
        
    }
}