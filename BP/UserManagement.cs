using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BenefitPro.Common.BaseClass;
using BenefitPro.Common.PageObjects.Administartion;

namespace BenefitPro.Administration
{
    [TestFixture, Order(1)]
    public class UserManagement : BaseTest
    {
        private UserManagementPage userManagementPage;
        private bool ShouldRunTests()
        {
            string userInput = TestContext.Parameters["RunTests"];
            return string.Equals(userInput, "yes", StringComparison.OrdinalIgnoreCase);
        }

        [SetUp]
        public void SetUp()
        {
            if (!ShouldRunTests())
            {
                Assert.Ignore("Tests skipped by user choice.");
            }

            userManagementPage = new UserManagementPage(driver);
            userManagementPage.AdministrationLink.Click();
            userManagementPage.UserManagementLink.Click();
        }

        //[SetUp]
        //public void SetUp()
        //{
        //    userManagementPage = new UserManagementPage(driver);
        //    userManagementPage.AdministrationLink.Click();
        //    userManagementPage.UserManagementLink.Click();
        //}



        [Test]
        public void AddUsers()
        {

            userManagementPage.AddButton.Click();
            userManagementPage.NativeDirectory.Click();
            userManagementPage.UserNameInput.SendKeys("");
            userManagementPage.PasswordInput.SendKeys("");
            userManagementPage.FirstNameInput.SendKeys("");
            userManagementPage.LastNameInput.SendKeys("");
            userManagementPage.Checkbox.Click();
            userManagementPage.RoleDropdown.Click();
            userManagementPage.TesterRoleOption.Click();
        }

        [Test]
        public void ModifyUsers()
        {

            string usernameToModify = "ConfigAdmin";
            var userRow = driver.FindElement(By.XPath($"//tr[contains(., '{usernameToModify}')]"));
            var editIcon = userRow.FindElement(By.ClassName("pi-pencil"));
            editIcon.Click();
            string newFirstName = "";
            string newLastName = "";
            userManagementPage.FirstNameInput.Clear();
            userManagementPage.FirstNameInput.SendKeys(newFirstName);
            userManagementPage.LastNameInput.Clear();
            userManagementPage.LastNameInput.SendKeys(newLastName);
        }
    }
}
