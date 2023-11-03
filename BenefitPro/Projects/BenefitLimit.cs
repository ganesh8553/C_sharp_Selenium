using BenefitPro.Common.BaseClass;
using BenefitPro.Common.PageObjects.Projects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro.Projects
{
    [TestFixture]
    public class BenefitLimit:BaseTest
    {
         public BenefitLimitPage benefitLimitPage;
        [SetUp]
        public void Setup()
        {
            Thread.Sleep(3000);
            benefitLimitPage = new BenefitLimitPage(driver);
            Thread.Sleep(3000);
            benefitLimitPage.ProjectsLink.Click();
            Thread.Sleep(3000);
            benefitLimitPage.Benefit_Limits_Link.Click();
            Thread.Sleep(3000);
            benefitLimitPage.BenefitLmitLink.Click();
            
        }

        [Test]
        public void Limits()
        {
            Thread.Sleep(3000);
            benefitLimitPage.Product.Click();
            benefitLimitPage.ProductID.Click();
            benefitLimitPage.EffectiveDate.Click();
            //benefitLimitPage.SubmitButton.Click();
        }
    }
}
