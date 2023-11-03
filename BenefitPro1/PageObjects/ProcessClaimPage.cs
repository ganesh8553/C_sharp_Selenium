using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.PageObjects
{
    public class ProcessClaimPage
    {
          public IWebElement ProjectsLink => Browser.driver.FindElement(By.XPath("//div[@class='p-panelmenu-panel']//..//span[text()='Projects']"));
         public IWebElement ProcessClaimLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Process Claim']"));
         public IWebElement ProjectNameDropdown => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select a Project Name']"));
         public IWebElement ProjectDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='SMALL GROUP']"));
         public IWebElement ProductIDDropdown => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select a Product ID']"));
         public IWebElement ProductIDDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='PMG10036']"));
         public IWebElement ServiceCategoryDropdown => Browser.driver.FindElement(By.XPath("//span[text()='Select  Service Category']"));
         public IWebElement ServiceCategoryDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='ALL']"));
         public IWebElement TierDropdownLink => Browser.driver.FindElement(By.XPath("//span[@class='p-dropdown-label p-inputtext p-placeholder']"));
        public IWebElement RangeDateFromLink => Browser.driver.FindElement(By.XPath("//input[@name='strDFrmDate']"));
        public IWebElement RangeDateToLink => Browser.driver.FindElement(By.XPath("//input[@name='strDToDate']"));
        public IWebElement CommentsLink => Browser.driver.FindElement(By.XPath("//textarea[contains(@class, 'p-inputtextarea')]"));
         public IWebElement ProcessButton => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Process']"));
        public IWebElement LoadButton => Browser.driver.FindElement(By.XPath("//span[text()='Load']"));
    }
}
