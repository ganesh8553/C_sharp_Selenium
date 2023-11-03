
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BenefitPro.Common.BaseClass;
using BenefitPro.Common.PageObjects.Administration;

namespace BenefitPro.Administration
{
    [TestFixture,Order(2)]
    public class RoleManagement : BaseTest
    {
        public RoleManagementPage roleManagementPage;

        [SetUp]
        public void SetUp()
        {
            Thread.Sleep(2000);
            roleManagementPage = new RoleManagementPage(driver);
            roleManagementPage.AdministrationLink.Click();
            roleManagementPage.RoleManagementLink.Click();
            Thread.Sleep(4000);
        }

        [Test]
        public void AddRoles()
        {
            roleManagementPage.AddButton.Click();
            roleManagementPage.RoleNameInput.SendKeys("");
            roleManagementPage.SelectAllButton.Click();
            roleManagementPage.UnselectAllButton.Click();
            roleManagementPage.SaveButton.Click();
            roleManagementPage.CancelButton.Click();
        }

        [Test]
        public void ModifyRoles()
        {
            string roleToModify = "Configuser";
            Thread.Sleep(2000);
            var roleRow = driver.FindElement(By.XPath($"//tr[contains(., '{roleToModify}')]"));
            var editIcon = roleRow.FindElement(By.CssSelector("i.pi.pi-pencil.edit-icon"));
            editIcon.Click();
            Thread.Sleep(2000);
            roleManagementPage.RoleNameInput.Clear();
            Thread.Sleep(2000);
            roleManagementPage.RoleNameInput.SendKeys("ConfigUser");
            Thread.Sleep(2000);
            roleManagementPage.SelectAllButton.Click();
            Thread.Sleep(2000);
            roleManagementPage.SaveButton.Click();
        }
    }
}

