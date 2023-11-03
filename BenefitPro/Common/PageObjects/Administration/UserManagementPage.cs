using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BenefitPro.Common.PageObjects.Administartion
{
    public class UserManagementPage
    {

        public IWebDriver driver;

        public UserManagementPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement AdministrationLink => driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement UserManagementLink => driver.FindElement(By.XPath("//span[normalize-space()='User Management']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@aria-label='Add']"));
        public IWebElement NativeDirectory => driver.FindElement(By.XPath("//div[@class='flex align-items-center']/label[text()='Native Directory']"));
        public IWebElement UserNameInput => driver.FindElement(By.XPath("//input[@id='strUsrNme']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@placeholder='Enter Password']"));
        public IWebElement FirstNameInput => driver.FindElement(By.XPath("//input[@id='strFNme']"));
        public IWebElement LastNameInput => driver.FindElement(By.XPath("//input[@id='strLNme']"));
        public IWebElement Checkbox => driver.FindElement(By.XPath("//div[@class='p-checkbox-box']"));
        public IWebElement RoleDropdown => driver.FindElement(By.XPath("//span[@class='p-dropdown-label p-inputtext p-placeholder']"));
        public IWebElement TesterRoleOption => driver.FindElement(By.XPath("//li[@aria-label='Tester']"));
         public IWebElement AdministratorRoleOption => driver.FindElement(By.XPath("//li[@aria-label='Administrator']"));
         public IWebElement UserRoleOption => driver.FindElement(By.XPath("//li[@aria-label='User']"));
         public IWebElement ConfiguserRoleOption => driver.FindElement(By.XPath("//li[@aria-label='Configuser']"));
         public IWebElement SupervisorRoleOption => driver.FindElement(By.XPath("//li[@aria-label='Supervisor']"));
        public IWebElement SaveButton => driver.FindElement(By.XPath("//button[text()='Save']"));
        public IWebElement CancelButton => driver.FindElement(By.XPath("//button[text()='Cancel']"));
    }
}
