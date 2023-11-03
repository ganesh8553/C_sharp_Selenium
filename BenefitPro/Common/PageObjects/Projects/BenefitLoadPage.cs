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
    public class BenefitLoadPage
    {
        public IWebDriver driver;
        private WebDriverWait wait;

        public BenefitLoadPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120)); // Change the timeout value as needed (e.g., 10 seconds).
        }

        public IWebElement ProjectsLink => wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='p-panelmenu-panel']/div[@class='p-component p-panelmenu-header']/a[@class='p-panelmenu-header-link']/span[text()='Projects']")));
        public IWebElement ChooseButton => driver.FindElement(By.XPath("//span[@class='p-button p-component p-fileupload-choose']"));
        public IWebElement Benefit_Limits_Link => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='p-panelmenu-panel']//span[text()='Benefits & Limits']")));
        public IWebElement BenefitLoadLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[normalize-space()='Benefit Load']")));
        public IWebElement EditProductLink => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[normalize-space()='Edit Product']")));
        public IWebElement Product => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='p-dropdown-label p-inputtext p-placeholder']")));
        public IWebElement ProductID => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@aria-label='PMG10036']")));
        public IWebElement EffectiveDate => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='p-inputtext p-component p-filled']")));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[normalize-space()='Submit']"));
        public IWebElement BenefitProduct => driver.FindElement(By.XPath("//span[text()='Select Product']"));
        public IWebElement BenefitProductOption => driver.FindElement(By.XPath("//div[@class='p-dropdown-panel p-component p-ripple-disabled p-connected-overlay-enter-done']//li[1]"));
        public IWebElement UploadButton => driver.FindElement(By.XPath("//span[normalize-space()='Upload']"));
        public IWebElement ClearButton => driver.FindElement(By.XPath("//button[normalize-space()='Clear']"));




    }
}
