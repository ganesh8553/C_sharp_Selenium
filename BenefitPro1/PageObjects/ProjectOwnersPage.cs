using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.PageObjects
{
    public class ProjectOwnersPage
    {
        public IWebElement ProjectsLink => Browser.driver.FindElement(By.XPath("//div[@class='p-panelmenu-panel']//..//span[text()='Projects']"));
        public IWebElement ProjectOwnersLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Project Owners']"));
        public IWebElement AddButton => Browser.driver.FindElement(By.XPath("\r\n//span[normalize-space()='Add']"));
        public IWebElement SelectAProjectNameDropdown => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select a Project Name']"));
        public IWebElement SelectProductID => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select Product ID']"));
        public IWebElement SelectAOwnerName => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select a Owner Name']"));
        public IWebElement  SaveButton=> Browser.driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement  CancelButton=> Browser.driver.FindElement(By.XPath("//button[@class='p-button p-component cancelbutton']"));
        public IWebElement  ModifyButton=> Browser.driver.FindElement(By.XPath("//tr[@draggable='false']//i[@class='pi pi-pencil edit-icon']"));
        


         
    }
}
