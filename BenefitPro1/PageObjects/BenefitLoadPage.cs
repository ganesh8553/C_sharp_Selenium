using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace BenefitPro1.PageObjects
{
        public class BenefitLoadPage
    {
        public IWebDriver driver;
        private WebDriverWait wait;

       
        public IWebElement ProjectsLink => Browser.driver.FindElement(By.XPath("//div[@class='p-panelmenu-panel']/div[@class='p-component p-panelmenu-header']/a[@class='p-panelmenu-header-link']/span[text()='Projects']"));
        public IWebElement ChooseButton => Browser.driver.FindElement(By.XPath("//span[@class='p-button p-component p-fileupload-choose']"));
        public IWebElement SelectProductOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='PMG10036']"));
        public IWebElement Benefit_Limits_Link =>  Browser.driver.FindElement(By.XPath("//div[@class='p-panelmenu-panel']//span[text()='Benefits & Limits']"));
        public IWebElement SelectProductDropdown => Browser.driver.FindElement(By.XPath("//span[@class='p-dropdown-label p-inputtext p-placeholder']"));
        public IWebElement BenefitLoadLink =>  Browser.driver.FindElement(By.XPath("//span[normalize-space()='Benefit Load']"));
        public IWebElement EditProductLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Edit Product']"));
        public IWebElement Product =>  Browser.driver.FindElement(By.XPath("//span[@class='p-dropdown-label p-inputtext p-placeholder']"));
        public IWebElement ProductID => Browser.driver.FindElement(By.XPath("//li[@aria-label='PMG10036']"));
        public IWebElement EffectiveDate =>  Browser.driver.FindElement(By.XPath("//input[@class='p-inputtext p-component p-filled']"));
        public IWebElement SubmitButton => Browser.driver.FindElement(By.XPath("//button[normalize-space()='Submit']"));
        public IWebElement BenefitProduct => Browser.driver.FindElement(By.XPath("//span[text()='Select Product']"));
        public IWebElement BenefitProductOption => Browser.driver.FindElement(By.XPath("//div[@class='p-dropdown-panel p-component p-ripple-disabled p-connected-overlay-enter-done']//li[1]"));
        public IWebElement UploadButton => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Upload']"));
        public IWebElement ClearButton => Browser.driver.FindElement(By.XPath("//button[normalize-space()='Clear']"));




    }
}
