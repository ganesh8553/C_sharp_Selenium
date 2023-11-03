using BenefitPro.Common.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BenefitPro.Common.BaseClass
{
    public class BaseTest : BrowserUtility
    {
        [SetUp]
        public void BenefitProLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.PerformLogin("Administrator", "Admin@123");
        }
    }
}

