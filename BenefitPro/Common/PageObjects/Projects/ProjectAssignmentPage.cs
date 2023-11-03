using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro.Common.PageObjects.Projects
{
    public class ProjectAssignmentPage
    {
        
        public IWebDriver driver;

        public ProjectAssignmentPage(IWebDriver driver)
        {
            this.driver = driver;
        }
         public IWebElement ProjectsLink => driver.FindElement(By.XPath("//div[@class='p-panelmenu-panel']//..//span[text()='Projects']"));
        public IWebElement ProjectAssignmentLink => driver.FindElement(By.XPath("//span[normalize-space()='Project Assignment']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@aria-label='Add']"));
    }
}
