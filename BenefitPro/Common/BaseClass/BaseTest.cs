using BenefitPro.Common.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BenefitPro.Common.BaseClass
{
    public class BaseTest : BrowserUtility
    {
        public IWebDriver driver;
       
        public  void BenefitProLogin()
        {
            Thread.Sleep(2000);
            LoginPage loginPage = new LoginPage(driver);
            
        }
    }
}

