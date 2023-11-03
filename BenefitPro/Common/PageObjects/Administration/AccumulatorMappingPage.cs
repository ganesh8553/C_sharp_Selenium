using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro.Common.PageObjects.Administartion
{
    public class AccumulatorMappingPage
    {
        public IWebDriver driver;
        public WebDriverWait wait;


        public AccumulatorMappingPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement AdministrationLink => driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement AccumulatorMappingLink => driver.FindElement(By.XPath("//span[normalize-space()='Accumulator Mapping']"));

    }
}
