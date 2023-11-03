//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using BenefitPro.Common.BaseClass;
//using ExcelDataReader;
//using System;
//using System.Data;
//using System.IO;
//using System.Linq;
//using System.Text;
//using BenefitPro.Common.PageObjects.Administartion;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
//using NUnit.Framework;

//namespace BenefitPro.Administration
//{
//    [TestClass]
//    public class UserManagement1: BaseTest
//    {
//        public UserManagementPage userManagementPage;

//        [TestInitialize]
//        public void TestInitialize()
//        {
//            userManagementPage = new UserManagementPage(driver);
//            userManagementPage = new UserManagementPage(driver);
//            Thread.Sleep(5000);
//            userManagementPage.AdministrationLink.Click();
//            Thread.Sleep(5000);
//            userManagementPage.UserManagementLink.Click();
//            Thread.Sleep(5000);
//        }

//        [TestMethod]
//        public void AddUserTest()
//        {
//            userManagementPage = new UserManagementPage(driver);
//            userManagementPage = new UserManagementPage(driver);
//            Thread.Sleep(5000);
//            userManagementPage.AdministrationLink.Click();
//            Thread.Sleep(5000);
//            userManagementPage.UserManagementLink.Click();
//            Thread.Sleep(5000);

//            Thread.Sleep(5000);
//            userManagementPage.AdministrationLink.Click();
//            Thread.Sleep(5000);
//            userManagementPage.UserManagementLink.Click();
//            Thread.Sleep(5000);
//        }

//        // You can add more test methods here
        
//        [TestCleanup]
//        public void TestCleanup()
//        {
//            // Clean up resources, close browser, etc.
//        }
//    }
//}