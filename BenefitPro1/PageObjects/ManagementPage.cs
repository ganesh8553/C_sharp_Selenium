using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.PageObjects
{
    public class ManagementPage
    {
       


        
        public IWebElement AdministrationLink => Browser.driver.FindElement(By.XPath("//span[text()='Administration']"));
        public IWebElement ManagementLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Management']"));
        public IWebElement ServiceLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Service']"));
        public IWebElement CategoryLink => Browser.driver.FindElement(By.XPath("//div[@class='p-tabview-nav-content']/ul/li//span[normalize-space()='Category']"));
        public IWebElement ProjectLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Project']"));
        public IWebElement ProductLink => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Product']"));
        public IWebElement AddButton => Browser.driver.FindElement(By.XPath("//button[@aria-label='Add']"));
        public IWebElement ServiceInput => Browser.driver.FindElement(By.XPath("//input[@id='strSrvcNme']"));
        public IWebElement CategoryInput => Browser.driver.FindElement(By.XPath("//input[@id='strCatNme']"));
        public IWebElement ProjectInput => Browser.driver.FindElement(By.XPath("//input[@id='strProjNme']"));
        public IWebElement ProductInput => Browser.driver.FindElement(By.XPath("//input[@id='strPrdId']"));
        public IWebElement ProductLob => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select LOB']"));
        public IWebElement ProductLobOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='SMALL GROUP']"));
        public IWebElement ProductCategory => Browser.driver.FindElement(By.XPath("//span[normalize-space()='Select Category']"));
        public IWebElement ProductCategoryOption => Browser.driver.FindElement(By.XPath("//li[@aria-label='POS']"));
        public IWebElement SaveButton => Browser.driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement CancelButton => Browser.driver.FindElement(By.XPath("//button[@class='p-button p-component cancelbutton']"));


    }
}
