using BenefitPro.Common.BaseClass;
using BenefitPro.Common.PageObjects.Administartion;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras;
using SeleniumExtras.WaitHelpers;


namespace BenefitPro.Administration
{
    [TestFixture,Order(3)]
    public class Management : BaseTest
    {
        public ManagementPage managementPage;
        [SetUp]
        public void SetUp()
        {
            managementPage = new ManagementPage();
            managementPage.AdministrationLink.Click();
            managementPage.ManagementLink.Click();

        }
        [Test]
        public void AddService()
        {
            managementPage.ServiceLink.Click();


        }
        [Test]
        public void AddCategory()
        {
            managementPage.CategoryLink.Click();
            managementPage.AddButton.Click();
            managementPage.CategoryInput.SendKeys("");

        }
        [Test]
        public void AddProject()
        {
            managementPage.ProjectLink.Click();
            managementPage.AddButton.Click();
            managementPage.ProjectInput.SendKeys("");

        }
        [Test]
        public void AddProduct()
        {
            managementPage.ProductLink.Click();
            managementPage.AddButton.Click();
            //wait.Until(ExpectedConditions.ElementToBeClickable(managementPage.ProductLink));
            managementPage.ProductInput.SendKeys("");
            managementPage.ProductLob.Click();
            managementPage.ProductLobOption.Click();
            managementPage.ProductCategory.Click();
            managementPage.ProductCategoryOption.Click();

        }

    }
}
