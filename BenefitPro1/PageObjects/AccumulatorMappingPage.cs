using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.PageObjects
{
    public class AccumulatorMappingPage
    {
        public IWebElement AdministrationLink => Browser.driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement AccumulatorMappingLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Accumulator Mapping']"));
        public IWebElement InNetworkDeductibleIndividual => Browser.driver.FindElement(By.XPath("//input[@title='In Network Deductible Individual']"));
         public IWebElement InNetworkDeductibleFamily => Browser.driver.FindElement(By.XPath("//input[@title='In Network Deductible Family']"));
        public IWebElement InNetworkLimitIndividual => Browser.driver.FindElement(By.XPath("//input[@title='In Network Limit Individual']"));
          public IWebElement InNetworkLimitFamily => Browser.driver.FindElement(By.XPath("//input[@title='In Network Limit Family']"));
         public IWebElement OutOfNetworkDeductibleIndividual => Browser.driver.FindElement(By.XPath("//input[@title='Out Of Network Deductible Individual']"));
         public IWebElement OutOfNetworkDeductibleFamily => Browser.driver.FindElement(By.XPath("//input[@title='Out Of Network Deductible Family']"));
        public IWebElement OutOfNetworkLimitIndividual => Browser.driver.FindElement(By.XPath("//input[@title='Out Of Network Limit Individual']"));
          public IWebElement OutOfNetworkLimitFamily => Browser.driver.FindElement(By.XPath("//input[@title='Out Of Network Limit Family']"));
        public IWebElement SubmitButton => Browser.driver.FindElement(By.XPath("//button[@type='submit']"));
  
    }
}
