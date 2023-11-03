using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.PageObjects
{
    public class ProcessBenefitPage
    {
         public IWebElement ProjectsLink => Browser.driver.FindElement(By.XPath("//div[@class='p-panelmenu-panel']//..//span[text()='Projects']"));
         public IWebElement ProcessBenefitLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Process Benefit']"));
         public IWebElement ProjectNameDropdown => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select a Project Name']"));
         public IWebElement ProjectDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='SMALL GROUP']"));
         public IWebElement ProductIDDropdown => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select a Product ID']"));
         public IWebElement ProductIDDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='PMG10036']"));
        public IWebElement OptionsCheckBox => Browser.driver.FindElement(By.XPath("//label[text()='Deductible']"));
         public IWebElement ServiceCategoryDropdown => Browser.driver.FindElement(By.XPath("//span[text()='Select a  Service Category']"));
         public IWebElement ServiceCategoryDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='ALL']"));
         public IWebElement CommentsLink => Browser.driver.FindElement(By.XPath("//textarea[contains(@class, 'p-inputtextarea')]"));
         public IWebElement RunButton => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Run']"));
        public IWebElement ResetButton => Browser.driver.FindElement(By.XPath("//button[@type='reset']"));

    }
}
