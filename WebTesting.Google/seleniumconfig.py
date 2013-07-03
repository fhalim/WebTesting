# Local firefox webdriver
#from OpenQA.Selenium.Firefox import FirefoxDriver
#webdriver = FirefoxDriver()

#SauceLab Webdriver
from OpenQA.Selenium.Remote import DesiredCapabilities,RemoteWebDriver, CapabilityType
from OpenQA.Selenium import Platform, PlatformType
from System import Uri
capabilities = DesiredCapabilities.Firefox()
capabilities.SetCapability(CapabilityType.Version, "10")
capabilities.SetCapability(CapabilityType.Platform, Platform(PlatformType.XP))
capabilities.SetCapability("name", "Testing Selenium 2 with IronPython on Sauce")
capabilities.SetCapability("username", "SAUCELAB_USER")
capabilities.SetCapability("accessKey", "SAUCELAB_ACCESSKEY")
webdriver = RemoteWebDriver(Uri("http://ondemand.saucelabs.com:80/wd/hub"), capabilities)