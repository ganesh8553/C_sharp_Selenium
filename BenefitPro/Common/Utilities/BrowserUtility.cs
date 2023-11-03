using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace BenefitPro.Common.Utilities
{
    [TestFixture]
    public class BrowserUtility
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        
        public void LaunchBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            driver.Navigate().GoToUrl("http://192.168.2.12:4801/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
