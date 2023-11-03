using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.PageObjects
{
    public  class AddRolesPage
    {
        public IWebDriver driver=null;
        public AddRolesPage()
        {
            this.driver = driver;
        }
        public IWebElement AdministrationLink => Browser.driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement RoleManagementLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Role Management']"));
        public IWebElement AddButton => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Add']"));
        public IWebElement RoleNameInput => Browser.driver.FindElement(By.XPath("//input[@id='rolE_NAME']"));
        public IWebElement SelectAllButton => Browser.driver.FindElement(By.XPath("//button[normalize-space()='Select All']"));
        public IWebElement UnselectAllButton => Browser.driver.FindElement(By.XPath("//button[normalize-space()='Unselect All']"));
        public IWebElement SaveButton => Browser.driver.FindElement(By.XPath("//button[@aria-label='Save']"));
        public IWebElement CancelButton => Browser.driver.FindElement(By.XPath("//button[@class='p-button p-component cancelbutton']"));
        public IWebElement EditButtonOption => Browser.driver.FindElement(By.XPath("//tr[@draggable='false']//i[@class='pi pi-pencil edit-icon']"));
    }
}


    

