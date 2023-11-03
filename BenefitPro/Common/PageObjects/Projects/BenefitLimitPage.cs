using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace BenefitPro.Common.PageObjects.Projects
{
    public class BenefitLimitPage
    {
                public IWebDriver driver;
        private WebDriverWait wait;

        public BenefitLimitPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120)); // Change the timeout value as needed (e.g., 10 seconds).
        }
        public IWebElement Benefit_Limits_Link => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='p-panelmenu-panel']//span[text()='Benefits & Limits']")));
        public IWebElement ProjectsLink => wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='p-panelmenu-panel']/div[@class='p-component p-panelmenu-header']/a[@class='p-panelmenu-header-link']/span[text()='Projects']")));
        public IWebElement BenefitLmitLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@role='none']//li[2]//a[1]")));
        public IWebElement EditProductLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[normalize-space()='Edit Product']")));
        public IWebElement Product => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='p-dropdown-label p-inputtext p-placeholder']")));
        public IWebElement ProductID => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@aria-label='PMG10036']")));
        public IWebElement EffectiveDate => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='p-inputtext p-component p-filled']")));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[normalize-space()='Submit']"));

    }
}
