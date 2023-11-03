using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro.Common.PageObjects.Administartion
{
    public class BenchmarkManagementPage
    {
        public IWebDriver driver;

        public BenchmarkManagementPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement AdministrationLink => driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement BenchmarkManagementLink => driver.FindElement(By.XPath("//span[normalize-space()='Benchmark Management']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//span[normalize-space()='Add']"));
        public IWebElement ManualEntryButton => driver.FindElement(By.XPath("//button[normalize-space()='Manual Entry']"));
        public IWebElement BenchmarkInput => driver.FindElement(By.XPath("//input[@id='_strBenchmarkName']"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[normalize-space()='Submit']"));
        public IWebElement FileButton => driver.FindElement(By.XPath("//button[normalize-space()='From File']"));
        public IWebElement BenchmarkFileInput => driver.FindElement(By.XPath("//input[@placeholder='Enter Name']"));
        public IWebElement ChooseButton => driver.FindElement(By.XPath("//span[@class='p-button p-component p-fileupload-choose']"));
        public IWebElement UploadButton => driver.FindElement(By.XPath("//button[@aria-label='Upload']"));
        public IWebElement Claims => driver.FindElement(By.XPath("//a[normalize-space()='SAMPLE1']"));
        public IWebElement UploadClaims => driver.FindElement(By.XPath("//span[normalize-space()='Upload Claims']"));






    }
}
