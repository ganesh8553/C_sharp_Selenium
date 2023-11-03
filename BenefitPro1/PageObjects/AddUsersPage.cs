using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.PageObjects
{
    public class AddUsersPage
    {

        public IWebDriver driver=null;

        public AddUsersPage()
        {
            this.driver = driver;
        }
        public IWebElement AdministrationLink => Browser.driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement UserManagementLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='User Management']"));
        public IWebElement AddButton => Browser.driver.FindElement(By.XPath("//button[@aria-label='Add']"));
        public IWebElement NativeDirectory => Browser.driver.FindElement(By.XPath("//div[@class='flex align-items-center']/label[text()='Native Directory']"));
        public IWebElement UserNameInput => Browser.driver.FindElement(By.XPath("//input[@id='strUsrNme']"));
        public IWebElement PasswordInput => Browser.driver.FindElement(By.XPath("//input[@placeholder='Enter Password']"));
        public IWebElement FirstNameInput => Browser.driver.FindElement(By.XPath("//input[@id='strFNme']"));
        public IWebElement LastNameInput => Browser.driver.FindElement(By.XPath("//input[@id='strLNme']"));
        public IWebElement Checkbox => Browser.driver.FindElement(By.XPath("//div[@class='p-checkbox-box']"));
        public IWebElement RoleDropdown => Browser.driver.FindElement(By.XPath("//span[@class='p-dropdown-label p-inputtext p-placeholder']"));
        public IWebElement TesterRoleOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='Tester']"));
         public IWebElement AdministratorRoleOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='Administrator']"));
         public IWebElement UserRoleOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='User']"));
         public IWebElement ConfiguserRoleOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='Configuser']"));
         public IWebElement SupervisorRoleOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='Supervisor']"));
        public IWebElement SaveButton => Browser.driver.FindElement(By.XPath("//button[text()='Save']"));
        public IWebElement CancelButton => Browser.driver.FindElement(By.XPath("//button[text()='Cancel']"));
    }
}
