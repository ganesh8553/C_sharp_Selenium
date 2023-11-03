using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro.Common.PageObjects.Administartion
{
    public class ManagementPage
    {
        public IWebDriver driver;
        public WebDriverWait wait;


        public ManagementPage()
        {
            this.driver = driver;
        }
        public IWebElement AdministrationLink =>driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement ManagementLink => driver.FindElement(By.XPath("//span[normalize-space()='Management']"));
        public IWebElement ServiceLink => driver.FindElement(By.XPath("//span[normalize-space()='Service']"));
        public IWebElement CategoryLink => driver.FindElement(By.XPath("//div[@class='p-tabview-nav-content']/ul/li//span[normalize-space()='Category']"));
        public IWebElement ProjectLink => driver.FindElement(By.XPath("//span[normalize-space()='Project']"));
        public IWebElement ProductLink => driver.FindElement(By.XPath("//span[normalize-space()='Product']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@aria-label='Add']"));
        public IWebElement ServiceInput => driver.FindElement(By.XPath("//input[@id='strSrvcNme']"));
        public IWebElement CategoryInput => driver.FindElement(By.XPath("//input[@id='strCatNme']"));
        public IWebElement ProjectInput => driver.FindElement(By.XPath("//input[@id='strProjNme']"));
        public IWebElement ProductInput => driver.FindElement(By.XPath("//input[@id='strPrdId']"));
        public IWebElement ProductLob => driver.FindElement(By.XPath("//span[normalize-space()='Select LOB']"));
        public IWebElement ProductLobOption => driver.FindElement(By.XPath("//li[@aria-label='SMALL GROUP']"));
        public IWebElement ProductCategory => driver.FindElement(By.XPath("//span[normalize-space()='Select Category']"));
        public IWebElement ProductCategoryOption => driver.FindElement(By.XPath("//li[@aria-label='POS']"));



    }
}
