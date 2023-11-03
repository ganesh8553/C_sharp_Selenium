using AutoIt;
using BenefitPro.Common.BaseClass;
using NUnit.Framework;
using System.Windows;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenefitPro.Common.PageObjects.Administartion;

namespace BenefitPro.Administration
{
    [TestFixture,Order(4)]
    public class BenchmarkManagement : BaseTest
    {
        public BenchmarkManagementPage benchmarkManagementPage;
        [SetUp]
        public void DefaultSetUp()
        {
            benchmarkManagementPage = new BenchmarkManagementPage(driver);
            benchmarkManagementPage.AdministrationLink.Click();
            benchmarkManagementPage.BenchmarkManagementLink.Click();
            

        }
        [Test]
        public void AddBenchmarkFromManualEntry()
        {
            benchmarkManagementPage.AddButton.Click();
            benchmarkManagementPage.ManualEntryButton.Click();
            benchmarkManagementPage.BenchmarkInput.SendKeys("");
            //benchmarkManagementPage.SubmitButton.Click();
        }
        [Test]
        public void AddBenchmarkFromFile()
        {
            benchmarkManagementPage.AddButton.Click();
            benchmarkManagementPage.FileButton.Click();
            benchmarkManagementPage.BenchmarkFileInput.SendKeys("");
            benchmarkManagementPage.ChooseButton.Click();   
            AutoItX.WinActivate("Open");
            Thread.Sleep(2000);
            AutoItX.Send("C:\\Users\\ganeshs\\Downloads\\X222-encounter.edi");
            Thread.Sleep(2000);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(5000);
            //benchmarkManagementPage.SubmitButton.Click();
        }

        [Test]
        public void UploadBenchmarkSampleEDIFile()
        {
            benchmarkManagementPage.UploadButton.Click();
            benchmarkManagementPage.ChooseButton.Click();
            AutoItX.WinActivate("Open");
            Thread.Sleep(2000);
            AutoItX.Send("C:\\Users\\ganeshs\\Downloads\\X222-encounter.edi");
            Thread.Sleep(2000);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(5000);
            //benchmarkManagementPage.SubmitButton.Click();
        }
        [Test]
        public void UploadClaims()
        {
            benchmarkManagementPage.Claims.Click();
            benchmarkManagementPage.UploadClaims.Click();
            benchmarkManagementPage.ChooseButton.Click();
            AutoItX.WinActivate("Open");
            Thread.Sleep(2000);
            AutoItX.Send("C:\\Users\\ganeshs\\Downloads\\X222-encounter.edi");
            Thread.Sleep(2000);
            AutoItX.Send("{ENTER}");
            Thread.Sleep(5000);
            //benchmarkManagementPage.SubmitButton.Click();

        }
    }
}

