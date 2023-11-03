using AutoIt;
using BenefitPro.Common.BaseClass;
using BenefitPro.Common.PageObjects.Administartion;
using BenefitPro.Common.PageObjects.Projects;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro.Projects
{
    [TestFixture]
    public class BenefitLoad : BaseTest
    {
        public BenefitLoadPage benefitLoadPage;
        [SetUp]
        public void Setup()
        {
            benefitLoadPage = new BenefitLoadPage(driver);
            Thread.Sleep(2000);
            benefitLoadPage.ProjectsLink.Click();
            Thread.Sleep(2000);
            benefitLoadPage.Benefit_Limits_Link.Click();
             benefitLoadPage.BenefitLoadLink.Click();
        }

        [Test]
        public void EditProduct()
        {
            benefitLoadPage.EditProductLink.Click();
            benefitLoadPage.Product.Click();
            benefitLoadPage.ProductID.Click();
            benefitLoadPage.EffectiveDate.Click();
            benefitLoadPage.SubmitButton.Click();
        }

        [Test]
        public void ImportBenefits()
        {
            Thread.Sleep(3000);
            benefitLoadPage.BenefitProduct.Click();
            Thread.Sleep(3000);
           benefitLoadPage.BenefitProductOption.Click();
            benefitLoadPage.ChooseButton.Click();
            AutoItX.WinActivate("Open");
            Thread.Sleep(2000);
            AutoItX.Send("C:\\Users\\ganeshs\\Downloads\\Benefis.xlsx");
            Thread.Sleep(2000);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(5000);
           //benefitLoadPage.UploadButton.Click();
           benefitLoadPage.ClearButton.Click();    

        }


    }
}

