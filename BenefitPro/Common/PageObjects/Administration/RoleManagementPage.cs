using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BenefitPro.Common.PageObjects.Administration
{
    public class RoleManagementPage
    {
        public IWebDriver driver;

        public RoleManagementPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AdministrationLink => driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement RoleManagementLink => driver.FindElement(By.XPath("//span[normalize-space()='Role Management']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//span[normalize-space()='Add']"));
        public IWebElement RoleNameInput => driver.FindElement(By.XPath("//input[@id='rolE_NAME']"));
        public IWebElement SelectAllButton => driver.FindElement(By.XPath("//button[normalize-space()='Select All']"));
        public IWebElement UnselectAllButton => driver.FindElement(By.XPath("//button[normalize-space()='Unselect All']"));
        public IWebElement SaveButton => driver.FindElement(By.XPath("//button[@aria-label='Save']"));
        public IWebElement CancelButton => driver.FindElement(By.XPath("//button[@class='p-button p-component cancelbutton']"));
        public IWebElement EditButtonOption => driver.FindElement(By.XPath("//tr[@draggable='false']//i[@class='pi pi-pencil edit-icon']"));
    }
}
