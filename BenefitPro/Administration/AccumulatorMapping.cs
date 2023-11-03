using BenefitPro.Common.BaseClass;
using BenefitPro.Common.PageObjects.Administartion;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro.Administration
{
    [TestFixture,Order(5)]
    public class AccumulatorMapping : BaseTest
    {
        

        public AccumulatorMappingPage accumulatorMappingPage;
        [SetUp]
        public void SetUp()
        {
            accumulatorMappingPage = new AccumulatorMappingPage(driver);
            accumulatorMappingPage.AdministrationLink.Click();
            accumulatorMappingPage.AccumulatorMappingLink.Click();

        }
        [Test]
        public void Accumulator()
        {
        }
    }
}
