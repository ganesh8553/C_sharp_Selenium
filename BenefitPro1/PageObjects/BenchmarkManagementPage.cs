using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.PageObjects
{
   public class BenchmarkManagementPage
    {
        public IWebDriver driver;

        public BenchmarkManagementPage()
        {
            this.driver = driver;
        }
        public IWebElement AdministrationLink => Browser.driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement BenchmarkManagementLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Benchmark Management']"));
        public IWebElement AddButton => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Add']"));
        public IWebElement ManualEntryButton => Browser.driver.FindElement(By.XPath("//button[normalize-space()='Manual Entry']"));
        public IWebElement BenchmarkInput => Browser.driver.FindElement(By.XPath("//input[@id='_strBenchmarkName']"));
        public IWebElement SubmitButton => Browser.driver.FindElement(By.XPath("//button[normalize-space()='Submit']"));
        public IWebElement FileButton => Browser.driver.FindElement(By.XPath("//button[normalize-space()='From File']"));
        public IWebElement BenchmarkFileInput => Browser.driver.FindElement(By.XPath("//input[@placeholder='Enter Name']"));
        public IWebElement ChooseButton => Browser.driver.FindElement(By.XPath("//span[@class='p-button p-component p-fileupload-choose']"));
        public IWebElement UploadButton => Browser.driver.FindElement(By.XPath("//button[@aria-label='Upload']"));
        public IWebElement Claims => Browser.driver.FindElement(By.XPath("//a[normalize-space()='SAMPLE1']"));
        public IWebElement UploadClaims => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Upload Claims']"));
        public IWebElement CloseButton => Browser.driver.FindElement(By.XPath("//div[@class='popup-f']//button[@class='p-button p-component cancelbutton'][normalize-space()='Close']"));
        public IWebElement ExistedBenchmarkUploadClaim => Browser.driver.FindElement(By.XPath("//a[normalize-space()='Test101']"));
        public IWebElement AddNewClaimButton => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Add New Claim']"));
        public IWebElement MemberAgeLow=> Browser.driver.FindElement(By.XPath("//input[@id='_iMemberAgeLow']"));
        public IWebElement MemberAgeHigh=> Browser.driver.FindElement(By.XPath("//input[@id='_iMemberAgeHigh']"));
        public IWebElement MemberGender=> Browser.driver.FindElement(By.XPath("//span[normalize-space()='Enter Member Gender']"));
        public IWebElement MemberGenderOption=> Browser.driver.FindElement(By.XPath("//li[@aria-label='Male']"));
        public IWebElement BillClass=> Browser.driver.FindElement(By.XPath("//input[@id='_sBillClass']"));
        public IWebElement POS=> Browser.driver.FindElement(By.XPath("//input[@id='_sPOS']"));
        public IWebElement ProviderTypeDropdown=> Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select type']"));
        public IWebElement ProviderTypeOption=> Browser.driver.FindElement(By.XPath("//li[@aria-label='INTERNAL MEDICINE']"));
        public IWebElement PCPDropdown=> Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select a Category']"));
        public IWebElement PCPOption=> Browser.driver.FindElement(By.XPath("//li[@aria-label='Yes']"));
        public IWebElement Diagnosis1=> Browser.driver.FindElement(By.XPath("//input[@id='_sDiag1']"));
        public IWebElement Diagnosis2=> Browser.driver.FindElement(By.XPath("//input[@id='_sDiag2']"));
        public IWebElement Diagnosis3=> Browser.driver.FindElement(By.XPath("//input[@id='_sDiag3']"));
        public IWebElement Diagnosis4=> Browser.driver.FindElement(By.XPath("//input[@id='_sDiag4']"));
        public IWebElement AddRowButton => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Add Row']"));


    }
}
  