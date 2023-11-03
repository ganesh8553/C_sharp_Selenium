using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.PageObjects
{
    public class ProjectAssignmentPage
    {
         public IWebElement ProjectsLink => Browser.driver.FindElement(By.XPath("//div[@class='p-panelmenu-panel']//..//span[text()='Projects']"));
        public IWebElement ProjectAssignmentLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Project Assignment']"));
        public IWebElement AddButton => Browser.driver.FindElement(By.XPath("//button[@aria-label='Add']"));
        public IWebElement SelectAProjectNameDropdown => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select a Project Name']"));
        public IWebElement SelectAProjectNameDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='LARGE GROUP']"));
        public IWebElement SelectAUserNameDropdown => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select a User Name']"));
        public IWebElement SelectAUserNameDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='Administrator']"));
        public IWebElement SelectProductIDDropdown => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select Product ID']"));
        public IWebElement SelectProductIDDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='PMG10036']"));
        public IWebElement SelectServiceCategoryDropdown => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select Service Category']"));
        public IWebElement SelectServiceCategoryDropdownOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='OUTPATIENT']"));
         public IWebElement SaveButton => Browser.driver.FindElement(By.XPath("//button[@type='submit']"));
         public IWebElement CancelButton => Browser.driver.FindElement(By.XPath("//button[@class='p-button p-component cancelbutton']"));
       



    }
}
