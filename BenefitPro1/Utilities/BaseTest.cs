
using System.IO;
using AutoIt;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using BenefitPro1.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using BenefitPro1.TestRepository;
using System.Text.RegularExpressions;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using Keys = OpenQA.Selenium.Keys;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using AventStack.ExtentReports.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace BenefitPro1.Utilities
{
    [TestClass]
    public class BaseTest
    {
        public IWebDriver driver;
        GenerateFile obj = new GenerateFile();
        FileObj fileObj = excelData.ReadExcel("");
        static ExcelData excelData = new ExcelData();
        AddUsersPage addUsersPage = new AddUsersPage();
        AddRolesPage addRolesPage = new AddRolesPage();
        ManagementPage managementPage = new ManagementPage();
        BenchmarkManagementPage benchmarkManagementPage = new BenchmarkManagementPage();
       AccumulatorMappingPage accumulatorMappingPage = new AccumulatorMappingPage();
        ProjectAssignmentPage projectAssignmentPage = new ProjectAssignmentPage();
        ProjectOwnersPage projectOwnersPage = new ProjectOwnersPage();
        ProcessBenefitPage processBenefitPage = new ProcessBenefitPage();
        ProcessClaimPage processClaimPage = new ProcessClaimPage();
        BenefitLoadPage benefitloadpage = new BenefitLoadPage();


        public TestCaseStatusObj AddUsers()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(3000);
                addUsersPage.AdministrationLink.Click();
                addUsersPage.UserManagementLink.Click();
                Thread.Sleep(2000);
                List<Add_Users> addUsersList = fileObj.addusersList;
                foreach (var userData in addUsersList)
                {
                    addUsersPage.AddButton.Click();
                    Thread.Sleep(3000);
                    addUsersPage.NativeDirectory.Click();
                    Thread.Sleep(3000);
                    string UserName = userData.User_Name;
                    string Password = userData.Password;
                    string FirstName = userData.First_Name;
                    string LastName = userData.Last_Name;
                    string SelectARole = userData.Select_A_Role;
                    bool isValid = true;
                    if (UserName.Length <= 8 && UserName.Length >= 20)
                    {
                        testCaseStatusObj.status = false;
                        addUsersPage.UserNameInput.SendKeys(UserName);
                        addUsersPage.PasswordInput.SendKeys(Password);
                        SampleTest.test.Log(Status.Warning, "Please provide a username with a minimum of 8 characters");
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("UserNameFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        addUsersPage.CancelButton.Click();
                        continue;
                       
                    }
                    if (!IsValid(Password))
                    {
                        testCaseStatusObj.status = false;
                        addUsersPage.PasswordInput.SendKeys(Password);
                        addUsersPage.FirstNameInput.SendKeys(FirstName);
                        SampleTest.test.Log(Status.Warning, "Password should contain at least 1 alphabet, 1 number, and 1 special character");
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("PasswordFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        addUsersPage.CancelButton.Click();
                        continue;
                        
                    }
                    if (FirstName.Length < 1)
                    {
                        testCaseStatusObj.status = false;
                        addUsersPage.FirstNameInput.SendKeys(FirstName);
                        addUsersPage.LastNameInput.SendKeys(LastName);
                        SampleTest.test.Log(Status.Warning, "First Name should contain atleast one character");
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("FirstNameFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        addUsersPage.CancelButton.Click();
                        continue;
                        
                    }
                    if (LastName.Length < 1)
                    {
                        testCaseStatusObj.status = false;
                        addUsersPage.LastNameInput.SendKeys(LastName);
                        addUsersPage.Checkbox.Click();
                        SampleTest.test.Log(Status.Warning, "Last Name should contain atleast one character");
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("LastNameFailureScreenshot.png");
                        addUsersPage.CancelButton.Click();
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        continue;
                      
                    }
                    if (isValid)
                    {
                        addUsersPage.UserNameInput.SendKeys(UserName);
                        addUsersPage.PasswordInput.SendKeys(Password);
                        addUsersPage.FirstNameInput.SendKeys(FirstName);
                        addUsersPage.LastNameInput.SendKeys(LastName);
                        addUsersPage.Checkbox.Click();
                        Thread.Sleep(2000);
                        IWebElement element = addUsersPage.RoleDropdown;
                        IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.driver;
                        js.ExecuteScript("arguments[0].scrollIntoView();", element);
                        element.Click();
                        Thread.Sleep(2000);
                        IWebElement roleOption = Browser.driver.FindElement(By.XPath($"//li[@aria-label='{SelectARole}']"));
                        roleOption.Click();
                        SampleTest.test.Log(Status.Pass, "User was successfully added");
                        addUsersPage.SaveButton.Click();
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Users");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddUsersTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public bool IsRoleAdded(string roleXPath)
        {
            try
            {
                return Browser.driver.FindElement(By.XPath(roleXPath)).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }
        public TestCaseStatusObj AddRoles()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                addRolesPage.AdministrationLink.Click();
                Thread.Sleep(1000);
                addRolesPage.RoleManagementLink.Click();
                Thread.Sleep(3000);
                List<Add_Roles> addRolesList = fileObj.addrolesList;

                foreach (var roleData in addRolesList)
                {
                    string RoleName = roleData.Role_Name;
                    Thread.Sleep(1000);
                    if (!IsRoleAdded($"//tbody//td[text()='{RoleName}']"))
                    {
                        testCaseStatusObj.status = false;
                        SampleTest.test.Log(Status.Warning, $" {RoleName} Role is already exists ");

                    }
                    else
                    {
                        string ScreenSelection = roleData.Screen_Selection;
                        Thread.Sleep(1000);
                        bool isValid = true;
                        Thread.Sleep(3000);
                        addRolesPage.AddButton.Click();
                        Thread.Sleep(1000);
                        addRolesPage.RoleNameInput.SendKeys(RoleName);
                        if (ScreenSelection.ToLower() == "yes")
                        {
                            Thread.Sleep(1000);
                            addRolesPage.SelectAllButton.Click();
                            Thread.Sleep(2000);
                            addRolesPage.SaveButton.Click();
                            Thread.Sleep(6000);
                            SampleTest.test.Log(Status.Pass, "Add Roles Test has passed");
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(roleData.User_Management))
                            {
                                if (roleData.User_Management.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tr[td[text()='USER MANAGEMENT']]/td[3]//div[@class='p-checkbox-box']")).Click();
                                }
                                if (roleData.User_Management.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tr[td[text()='USER MANAGEMENT']]/td[4]//div[@class='p-checkbox-box']")).Click();
                                }
                                if (roleData.User_Management.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tr[td[text()='USER MANAGEMENT']]/td[5]//div[@class='p-checkbox-box']")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.BENEFIT_LOAD))
                            {
                                if (roleData.BENEFIT_LOAD.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[2]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.BENEFIT_LOAD.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[2]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.BENEFIT_LOAD.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[2]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PROJECT_STATUS_REPORT))
                            {
                                if (roleData.PROJECT_STATUS_REPORT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[3]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_STATUS_REPORT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[3]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_STATUS_REPORT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[3]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.ROLE_MANAGEMENT))
                            {
                                if (roleData.ROLE_MANAGEMENT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[4]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.ROLE_MANAGEMENT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[4]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.ROLE_MANAGEMENT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[4]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.SERVICE_MANAGEMENT))
                            {
                                if (roleData.SERVICE_MANAGEMENT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[5]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.SERVICE_MANAGEMENT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[5]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.SERVICE_MANAGEMENT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[5]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.CATEGORY_MANAGEMENT))
                            {
                                if (roleData.CATEGORY_MANAGEMENT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[6]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.CATEGORY_MANAGEMENT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[6]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.CATEGORY_MANAGEMENT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[6]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PRODUCT_MANAGEMENT))
                            {
                                if (roleData.PRODUCT_MANAGEMENT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[7]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PRODUCT_MANAGEMENT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[7]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PRODUCT_MANAGEMENT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[7]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.BENCHMARK_MANAGEMENT))
                            {
                                if (roleData.BENCHMARK_MANAGEMENT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[8]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.BENCHMARK_MANAGEMENT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[8]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.BENCHMARK_MANAGEMENT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[8]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.ACCUMULATOR_MANAGEMENT))
                            {
                                if (roleData.ACCUMULATOR_MANAGEMENT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[9]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.ACCUMULATOR_MANAGEMENT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[9]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.ACCUMULATOR_MANAGEMENT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[9]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PROJECT_ASSIGNMENT))
                            {
                                if (roleData.PROJECT_ASSIGNMENT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[10]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_ASSIGNMENT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[10]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_ASSIGNMENT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[10]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PROCESS_BENEFIT))
                            {
                                if (roleData.PROCESS_BENEFIT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[11]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROCESS_BENEFIT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[11]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROCESS_BENEFIT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[11]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PROCESS_CLAIM))
                            {
                                if (roleData.PROCESS_CLAIM.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[12]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROCESS_CLAIM.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[12]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROCESS_CLAIM.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[12]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PRODUCT_STATUS_REPORT))
                            {
                                if (roleData.PRODUCT_STATUS_REPORT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[13]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PRODUCT_STATUS_REPORT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[13]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PRODUCT_STATUS_REPORT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[13]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PRODUCT_BENEFIT_REPORT))
                            {
                                if (roleData.PRODUCT_BENEFIT_REPORT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[14]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PRODUCT_BENEFIT_REPORT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[14]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PRODUCT_BENEFIT_REPORT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[14]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PRODUCT_CLAIM_REPORT))
                            {
                                if (roleData.PRODUCT_CLAIM_REPORT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[15]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PRODUCT_CLAIM_REPORT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[15]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PRODUCT_CLAIM_REPORT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[15]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.DASHBOARD))
                            {
                                if (roleData.DASHBOARD.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[16]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.DASHBOARD.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[16]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.DASHBOARD.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[16]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PROJECT_MANAGEMENT))
                            {
                                if (roleData.PROJECT_MANAGEMENT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[17]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_MANAGEMENT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[17]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_MANAGEMENT.Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[17]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.CONFIG_TICKETS))
                            {
                                if (roleData.CONFIG_TICKETS.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[18]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.CONFIG_TICKETS.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[18]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.CONFIG_TICKETS.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[18]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.TICKET_MANAGEMENT))
                            {
                                if (roleData.TICKET_MANAGEMENT.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[19]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.TICKET_MANAGEMENT.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[19]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.TICKET_MANAGEMENT.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[19]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PROJECT_STATUS))
                            {
                                if (roleData.PROJECT_STATUS.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[20]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_STATUS.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[20]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_STATUS.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[20]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.PROJECT_OWNERS))
                            {
                                if (roleData.PROJECT_OWNERS.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[21]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_OWNERS.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[21]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.PROJECT_OWNERS.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[21]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            if (!string.IsNullOrEmpty(roleData.TICKETS))
                            {
                                if (roleData.TICKETS.ToLower().Contains("view"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[22]/td[3]/div[1]/div[2]")).Click();
                                }
                                if (roleData.TICKETS.ToLower().Contains("add"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[22]/td[4]/div[1]/div[2]")).Click();
                                }
                                if (roleData.TICKETS.ToLower().Contains("edit"))
                                {
                                    Browser.driver.FindElement(By.XPath("//tbody/tr[22]/td[5]/div[1]/div[2]")).Click();
                                }
                            }

                            Thread.Sleep(2000);
                            addRolesPage.SaveButton.Click();
                            Thread.Sleep(6000);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Roles");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddRolesTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj AddService()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                managementPage.AdministrationLink.Click();
                Thread.Sleep(3000);
                managementPage.ManagementLink.Click();
                Thread.Sleep(2000);
                List<Management> managemenTlist = fileObj.managementList;

                foreach (var serviceData in managemenTlist)
                {
                    managementPage.AddButton.Click();
                    Thread.Sleep(2000);
                    string ServiceName = serviceData.Add_Service;
                    if (ServiceName.Length >= 8)
                    {
                        managementPage.ServiceInput.SendKeys(ServiceName);
                        Thread.Sleep(1000);
                        managementPage.SaveButton.Click();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.status = false;
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        managementPage.CancelButton.Click();
                        return testCaseStatusObj;
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Service");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddServiceTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj AddCategory()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                managementPage.AdministrationLink.Click();
                Thread.Sleep(3000);
                managementPage.ManagementLink.Click();
                Thread.Sleep(2000);
                managementPage.CategoryLink.Click();
                List<Management> managemenTlist = fileObj.managementList;
                foreach (var categoryData in managemenTlist)
                {
                    managementPage.AddButton.Click();
                    Thread.Sleep(2000);
                    string CategoryName = categoryData.Add_Category;
                    if (CategoryName.Length >= 8)
                    {
                        managementPage.CategoryInput.SendKeys(CategoryName);
                        Thread.Sleep(1000);
                        managementPage.SaveButton.Click();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        managementPage.CategoryInput.SendKeys(CategoryName);
                        SampleTest.test.Log(Status.Warning, "Please provide correct category details ");
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("EndToEndTestFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        testCaseStatusObj.status = false;
                        managementPage.CancelButton.Click();
                        return testCaseStatusObj;
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Category");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddCategoryTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj AddProject()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                managementPage.AdministrationLink.Click();
                Thread.Sleep(3000);
                managementPage.ManagementLink.Click();
                Thread.Sleep(2000);
                managementPage.ProjectLink.Click();
                List<Management> managemenTlist = fileObj.managementList;
                foreach (var projectData in managemenTlist)
                {
                    managementPage.AddButton.Click();
                    Thread.Sleep(2000);
                    string ProjectName = projectData.Add_Project;
                    if (ProjectName.Length >= 8)
                    {
                        managementPage.ProjectInput.SendKeys(ProjectName);
                        Thread.Sleep(1000);
                        managementPage.SaveButton.Click();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        managementPage.ProjectInput.SendKeys(ProjectName);
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        testCaseStatusObj.status = false;
                        managementPage.CancelButton.Click();
                        return testCaseStatusObj;
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Category");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddCategoryTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj AddProduct()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                managementPage.AdministrationLink.Click();
                Thread.Sleep(3000);
                managementPage.ManagementLink.Click();
                Thread.Sleep(2000);
                managementPage.ProductLink.Click();
                List<Management> managemenTlist = fileObj.managementList;

                foreach (var productData in managemenTlist)
                {
                    managementPage.AddButton.Click();
                    Thread.Sleep(2000);
                    string ProductName = productData.Add_Product_ID;
                    string ProductLOB = productData.Select_LOB;
                    string ProductCategory = productData.Product_Category;
                    if (ProductName.Length >= 1 && ProductLOB.Length >= 1 && ProductCategory.Length >= 1)
                    {
                        managementPage.ProductInput.SendKeys(ProductName);
                        Thread.Sleep(1000);
                        managementPage.ProductLob.Click();
                        Thread.Sleep(1000);
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProductLOB}']"));
                        Thread.Sleep(1000);
                        managementPage.ProductCategory.Click();
                        Thread.Sleep(1000);
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProductCategory}']"));
                        Thread.Sleep(1000);
                        managementPage.SaveButton.Click();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        managementPage.ProductInput.SendKeys(ProductName);
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProductFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        testCaseStatusObj.status = false;
                        managementPage.CancelButton.Click();
                        return testCaseStatusObj;
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Product");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProductTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj AddCategoryE()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                //managementPage.AdministrationLink.Click();
                Thread.Sleep(3000);
                managementPage.ManagementLink.Click();
                Thread.Sleep(2000);
                managementPage.CategoryLink.Click();
                List<Management> managemenTlist = fileObj.managementList;
                foreach (var categoryData in managemenTlist)
                {
                    managementPage.AddButton.Click();
                    Thread.Sleep(2000);
                    string CategoryName = categoryData.Add_Category;
                    if (CategoryName.Length >= 8)
                    {
                        managementPage.CategoryInput.SendKeys(CategoryName);
                        Thread.Sleep(1000);
                        managementPage.SaveButton.Click();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        managementPage.CategoryInput.SendKeys(CategoryName);
                        SampleTest.test.Log(Status.Warning, "Please provide correct category details ");
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("EndToEndTestFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        SampleTest.test.Log(Status.Fail, "Add category test has failed");
                        testCaseStatusObj.status = false;
                        managementPage.CancelButton.Click();
                        return testCaseStatusObj;
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Category");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddCategoryTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }

        public TestCaseStatusObj AddBenchmarkManual()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                benchmarkManagementPage.AdministrationLink.Click();
                Thread.Sleep(2000);
                benchmarkManagementPage.BenchmarkManagementLink.Click();
                Thread.Sleep(2000);
                List<Add_Benchmark> addBenchmarkList = fileObj.addbenchmarkList;
                foreach (var benchmarkData in addBenchmarkList)
                {
                    benchmarkManagementPage.AddButton.Click();
                    Thread.Sleep(1000);
                    benchmarkManagementPage.ManualEntryButton.Click();
                    Thread.Sleep(1000);
                    string Benchmarkname = benchmarkData.Benchmark_Name;
                    if (Benchmarkname.Length >= 1)
                    {
                        benchmarkManagementPage.BenchmarkInput.SendKeys(Benchmarkname);
                        benchmarkManagementPage.SubmitButton.Click();
                    }
                    else
                    {
                        testCaseStatusObj.status = false;
                        benchmarkManagementPage.CloseButton.Click();
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddBenchmarkManualFailureScreenshot.png");
                    }

                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Benchmark");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddRolesTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }

        public TestCaseStatusObj AddBenchmarkFromFile()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                benchmarkManagementPage.AdministrationLink.Click();
                Thread.Sleep(2000);
                benchmarkManagementPage.BenchmarkManagementLink.Click();
                Thread.Sleep(2000);
                List<Add_Benchmark> addBenchmarkList = fileObj.addbenchmarkList;
                foreach (var benchmarkData in addBenchmarkList)
                {
                    benchmarkManagementPage.AddButton.Click();
                    Thread.Sleep(1000);
                    benchmarkManagementPage.FileButton.Click();
                    Thread.Sleep(1000);
                    string Benchmarkname = benchmarkData.Benchmark_Name;
                    string BenchmarkFilePath = benchmarkData.Benchmark_FilePath;
                    if (Benchmarkname.Length >= 1 && File.Exists(BenchmarkFilePath))
                    {
                        benchmarkManagementPage.BenchmarkFileInput.SendKeys(Benchmarkname);
                        Thread.Sleep(2000);
                        benchmarkManagementPage.ChooseButton.Click();
                        Thread.Sleep(1000);
                        AutoItX.WinActivate("Open");
                        Thread.Sleep(2000);
                        AutoItX.Send(BenchmarkFilePath);
                        Thread.Sleep(2000);
                        AutoItX.Send("{ENTER}");
                        Thread.Sleep(5000);
                        benchmarkManagementPage.SubmitButton.Click();
                    }
                    else
                    {
                        testCaseStatusObj.status = false;
                        benchmarkManagementPage.CloseButton.Click();
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddBenchmarkManualFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                    }

                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Benchmark");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddBenchmarkManualFailureScreenshot.png");
            }
            return testCaseStatusObj;

        }
        public TestCaseStatusObj AddBenchmarkSampleEdiFile()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                benchmarkManagementPage.AdministrationLink.Click();
                Thread.Sleep(2000);
                benchmarkManagementPage.BenchmarkManagementLink.Click();
                Thread.Sleep(2000);
                List<Add_Benchmark> addBenchmarkList = fileObj.addbenchmarkList;
                benchmarkManagementPage.UploadButton.Click();
                Thread.Sleep(1000);
                benchmarkManagementPage.ChooseButton.Click();
                Thread.Sleep(1000);

                foreach (var benchmarkData in addBenchmarkList)
                {
                    string BenchmarkFilePath = benchmarkData.Benchmark_FilePath;

                    if (File.Exists(BenchmarkFilePath))
                    {
                        Thread.Sleep(1000);
                        AutoItX.WinActivate("Open");
                        Thread.Sleep(2000);
                        AutoItX.Send(BenchmarkFilePath);
                        Thread.Sleep(2000);
                        AutoItX.Send("{ENTER}");
                        Thread.Sleep(5000);
                        benchmarkManagementPage.SubmitButton.Click();
                    }
                    else
                    {
                        testCaseStatusObj.status = false;
                        benchmarkManagementPage.CloseButton.Click();
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddBenchmarkManualFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                    }
                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Benchmark");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddBenchmarkManualFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj UploadClaimsFromFile()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                benchmarkManagementPage.AdministrationLink.Click();
                Thread.Sleep(2000);
                benchmarkManagementPage.BenchmarkManagementLink.Click();
                Thread.Sleep(2000);
                List<Add_Benchmark> addBenchmarkList = fileObj.addbenchmarkList;

                string Benchmarkname = addBenchmarkList[0].Benchmark_Name;
                bool isValid = true;
                if (isValid)
                {
                    string xpath = $"//a[normalize-space()='{Benchmarkname}']";
                    Browser.driver.FindElement(By.XPath(xpath)).Click();
                    benchmarkManagementPage.UploadClaims.Click();
                    benchmarkManagementPage.ChooseButton.Click();
                    Thread.Sleep(1000);
                    AutoItX.WinActivate("Open");
                    Thread.Sleep(2000);
                    AutoItX.Send("C:\\Users\\ganeshs\\Downloads\\X222-encounter.edi");
                    Thread.Sleep(2000);
                    AutoItX.Send("{ENTER}");
                    Thread.Sleep(5000);
                }
                else
                {
                    testCaseStatusObj.status = false;
                    benchmarkManagementPage.CloseButton.Click();
                    Screenshots screenshots = new Screenshots();
                    testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddBenchmarkManualFailureScreenshot.png");
                    SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                }

                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Benchmark");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddBenchmarkManualFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }

        public TestCaseStatusObj AddClaimsManually()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                benchmarkManagementPage.AdministrationLink.Click();
                Thread.Sleep(2000);
                benchmarkManagementPage.BenchmarkManagementLink.Click();
                Thread.Sleep(2000);
                List<Add_Benchmark> addBenchmarkList = fileObj.addbenchmarkList;
                IWebElement table = Browser.driver.FindElement(By.XPath("//div[@class='p-datatable-wrapper']"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.driver;
                js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight;", table);
                string Benchmarkname = addBenchmarkList[0].Benchmark_Name;
                bool isValid = true;
                if (isValid)
                {
                    string xpath = $"//a[normalize-space()='{Benchmarkname}']";
                    Thread.Sleep(2000);
                    Browser.driver.FindElement(By.XPath(xpath)).Click();
                    Thread.Sleep(2000);
                    benchmarkManagementPage.AddNewClaimButton.Click();
                    Thread.Sleep(2000);
                    benchmarkManagementPage.MemberAgeHigh.SendKeys("8");
                    Thread.Sleep(2000);
                    benchmarkManagementPage.MemberAgeLow.SendKeys("7");
                    Thread.Sleep(2000);
                    benchmarkManagementPage.MemberGender.Click();
                    Thread.Sleep(2000);
                    string MemberGenderOption = "Male";
                    Browser.driver.FindElement(By.XPath($"//li[@aria-label='{MemberGenderOption}']")).Click();
                    Thread.Sleep(2000);
                    //benchmarkManagementPage.BillClass.SendKeys("8");
                    benchmarkManagementPage.POS.SendKeys("9");
                    benchmarkManagementPage.ProviderTypeDropdown.Click();
                    benchmarkManagementPage.ProviderTypeOption.Click();
                    benchmarkManagementPage.PCPDropdown.Click();
                    string PCPOption = "Yes";
                    Browser.driver.FindElement(By.XPath($"//li[@aria-label='{PCPOption}']")).Click();
                    IJavaScriptExecutor jss = (IJavaScriptExecutor)Browser.driver;
                    jss.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    benchmarkManagementPage.Diagnosis1.SendKeys("1");
                    benchmarkManagementPage.Diagnosis2.SendKeys("3");
                    benchmarkManagementPage.Diagnosis3.SendKeys("4");
                    benchmarkManagementPage.Diagnosis4.SendKeys("5");
                    IJavaScriptExecutor j = (IJavaScriptExecutor)Browser.driver;
                    j.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    benchmarkManagementPage.AddRowButton.Click();
                }
                else
                {
                    testCaseStatusObj.status = false;
                    benchmarkManagementPage.CloseButton.Click();
                    Screenshots screenshots = new Screenshots();
                    testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddBenchmarkManualFailureScreenshot.png");
                    SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                }
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Benchmark");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddBenchmarkManualFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj BenefitLoad_Import_Benefits()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                benefitloadpage.ProjectsLink.Click();
                Thread.Sleep(1000);
                benefitloadpage.Benefit_Limits_Link.Click();
                Thread.Sleep(1000);
                benefitloadpage.BenefitLoadLink.Click();
                Thread.Sleep(1000);
                benefitloadpage.SelectProductDropdown.Click();
                Thread.Sleep(1000);

            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Project Assignment");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailureScreenshot.png");
                SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj AccumulatorMapping()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                accumulatorMappingPage.AdministrationLink.Click();
                Thread.Sleep(1000);
                accumulatorMappingPage.AccumulatorMappingLink.Click();
                Thread.Sleep(3000);
               
                List<Accumulator_Mapping> addAccumulatorList = fileObj.addaccumulatorList;
                 foreach (var accumulatordata in addAccumulatorList)
                {
                    string IDI = accumulatordata.IN_NETWORK_Deductible_Individual;
                    Thread.Sleep(2000);
                    accumulatorMappingPage.InNetworkDeductibleIndividual.Clear();
                    Thread.Sleep(2000);
                    accumulatorMappingPage.InNetworkDeductibleIndividual.SendKeys(IDI);
                      Thread.Sleep(2000);
                    string IDF = accumulatordata.IN_NETWORK_Deductible_Family;
                }
               accumulatorMappingPage.InNetworkDeductibleIndividual.SendKeys("");
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Project Assignment");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailureScreenshot.png");
                SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
            }
            return testCaseStatusObj;
        }

        public TestCaseStatusObj AddProjectAssignment()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                projectAssignmentPage.ProjectsLink.Click();
                Thread.Sleep(1000);
                projectAssignmentPage.ProjectAssignmentLink.Click();
                Thread.Sleep(1000);
                List<Add_Project_Assignment> addProjectAssignmentList = fileObj.addprojectAssignmentList;
                foreach (var Projectdata in addProjectAssignmentList)
                {
                    //projectAssignmentPage.AddButton.Click();
                    WebDriverWait wait = new WebDriverWait(Browser.driver, TimeSpan.FromSeconds(10));
                    IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(projectAssignmentPage.AddButton));
                    addButton.Click();
                    string ProjectName = Projectdata.Project_Name;
                    string UserName = Projectdata.User_Name;
                    string ProductID = Projectdata.Product_ID;
                    string ServiceCategory = Projectdata.Service_Category;

                    if (ProjectName.Length >= 1 && UserName.Length >= 1 && ProductID.Length >= 1 && ServiceCategory.Length >= 1)
                    {
                        Thread.Sleep(1000);
                        projectAssignmentPage.SelectAProjectNameDropdown.Click();
                        Thread.Sleep(1000);
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProjectName}']")).Click();
                        Thread.Sleep(1000);
                        projectAssignmentPage.SelectAUserNameDropdown.Click();
                        Thread.Sleep(1000);
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{UserName}']")).Click();
                        Thread.Sleep(1000);
                        projectAssignmentPage.SelectProductIDDropdown.Click();
                        Thread.Sleep(1000);
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProductID}']")).Click();
                        Thread.Sleep(1000);
                        projectAssignmentPage.SelectServiceCategoryDropdown.Click();
                        Thread.Sleep(1000);
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ServiceCategory}']")).Click();
                        projectAssignmentPage.SaveButton.Click();

                        if (IsToastMessageDisplayed())
                        {
                            testCaseStatusObj.status = false;
                            projectAssignmentPage.CancelButton.Click();
                            Screenshots screenshots = new Screenshots();
                            testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailureScreenshot.png");
                            SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        }
                    }
                    else
                    {
                        testCaseStatusObj.status = false;
                        projectAssignmentPage.CancelButton.Click();
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailureScreenshot.png");
                        SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Project Assignment");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailureScreenshot.png");
                SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj ProcessBenefit()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                processBenefitPage.ProjectsLink.Click();
                Thread.Sleep(2000);
                processBenefitPage.ProcessBenefitLink.Click();
                Thread.Sleep(2000);
                List<Process_Benefit> processBenefitList = fileObj.processbenefitList;
                foreach (var processbenefitData in processBenefitList)
                {
                    processBenefitPage.ProjectNameDropdown.Click();
                    Thread.Sleep(1000);
                    // processBenefitPage.ProjectDropdownOption.Click();
                    Thread.Sleep(1000);
                    string ProjectOption = processbenefitData.Project_Name;
                    Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProjectOption}']")).Click();
                    Thread.Sleep(1000);
                    processBenefitPage.ProductIDDropdown.Click();
                    Thread.Sleep(1000);
                    string ProductId = processbenefitData.Product_ID;
                    Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProductId}']")).Click();
                    Thread.Sleep(1000);
                    string Options = processbenefitData.Options;
                    Browser.driver.FindElement(By.XPath($"//label[text()='{Options}']")).Click();
                    Thread.Sleep(1000);
                    if (Options == "service")
                    {
                        processBenefitPage.ServiceCategoryDropdown.Click();
                        Thread.Sleep(1000);
                        string ServiceCategory = processbenefitData.Service_Category;
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ServiceCategory}']")).Click();
                    }
                    string Comments = processbenefitData.Comments;
                    processBenefitPage.CommentsLink.SendKeys(Comments);
                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Benchmark");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddRolesTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj ProcessClaim()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                processClaimPage.ProjectsLink.Click();
                Thread.Sleep(2000);
                processClaimPage.ProcessClaimLink.Click();
                Thread.Sleep(2000);
                List<Process_Claim> processClaimList = fileObj.processclaimList;
                foreach (var processclaimData in processClaimList)
                {
                    processClaimPage.ProjectNameDropdown.Click();
                    Thread.Sleep(1000);
                    string ProjectOption = processclaimData.Project_Name;
                    Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProjectOption}']")).Click();
                    Thread.Sleep(1000);
                    processClaimPage.ProductIDDropdown.Click();
                    Thread.Sleep(1000);
                    string ProductId = processclaimData.Product_ID;
                    Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProductId}']")).Click();
                    Thread.Sleep(1000);
                    processClaimPage.ServiceCategoryDropdown.Click();
                    Thread.Sleep(1000);
                    string ServiceCategory = processclaimData.Service_Category;
                    Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ServiceCategory}']")).Click();
                    processClaimPage.TierDropdownLink.Click();
                    Thread.Sleep(1000);
                    string Tier = processclaimData.Tier;
                    Browser.driver.FindElement(By.XPath($"//li[@aria-label='{Tier}']")).Click();
                    Thread.Sleep(2000);
                    string inputDate = processclaimData.Range_Date_From;
                    string formattedDate = ReformatDate(inputDate);
                    processClaimPage.RangeDateFromLink.SendKeys(formattedDate);
                    Thread.Sleep(2000);
                    Browser.driver.FindElement(By.XPath("//label[text()='Range Date To ']")).Click();
                    processClaimPage.RangeDateToLink.Click();
                    Thread.Sleep(1000);
                    string inputDate1 = processclaimData.Range_Date_To;
                    string formattedDate1 = ReformatDate(inputDate1);
                    processClaimPage.RangeDateToLink.SendKeys(formattedDate1);
                    Browser.driver.FindElement(By.XPath("//label[text()='Range Date From']")).Click();
                    Thread.Sleep(2000);
                    string Comments = processclaimData.Comments;
                    processBenefitPage.CommentsLink.SendKeys(Comments);
                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Process Claim ");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("ProcessClaimTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public string ReformatDate(string inputDate)
        {

            Match match = Regex.Match(inputDate, @"(\d{2})-(\d{2})-(\d{4})");

            if (match.Success)
            {
                string reformattedDate = $"{match.Groups[1].Value}/{match.Groups[2].Value}/{match.Groups[3].Value}";
                return reformattedDate;
            }
            return inputDate;
        }
        public TestCaseStatusObj ModifyProjectAssignment()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                projectAssignmentPage.ProjectsLink.Click();
                Thread.Sleep(1000);
                projectAssignmentPage.ProjectAssignmentLink.Click();
                Thread.Sleep(1000);
                List<Modify_Project_Assignment_Edit> modifyProjectAssignmentEditList = fileObj.modifyprojectAssignmentEditList;
                List<Modify_Project_Assignment> modifyProjectAssignmentList = fileObj.modifyprojectAssignmentList;

                foreach (var Projectdata in modifyProjectAssignmentEditList)
                {
                    string ProjectName = Projectdata.Project_Name;
                    string UserName = Projectdata.User_Name;
                    string ProductID = Projectdata.Product_ID;
                    string ServiceCategory = Projectdata.Service_Category;
                    IWebElement table = Browser.driver.FindElement(By.XPath($"//tr[td[contains(., '{ProjectName}')]][td[contains(., '{UserName}')]][td[contains(., '{ProductID}')]][td[contains(., '{ServiceCategory}')]]"));
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.driver;
                    js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight;", table);

                    foreach (var Projectdata1 in modifyProjectAssignmentList)
                    {
                        IWebElement editButton = Browser.driver.FindElement(By.XPath($"//tr[td[contains(., '{ProjectName}')]][td[contains(., '{UserName}')]][td[contains(., '{ProductID}')]][td[contains(., '{ServiceCategory}')]]//i[@class='pi pi-pencil edit-icon']"));
                        editButton.Click();
                        string ProjectName1 = Projectdata1.Project_Name;
                        string UserName1 = Projectdata1.Modify_User_Name;
                        string ProductID1 = Projectdata1.Modify_Product_ID;
                        string ServiceCategory1 = Projectdata1.Modify_Service_Category;

                        if (ProjectName1.Length >= 1 && UserName1.Length >= 1 && ProductID1.Length >= 1 && ServiceCategory1.Length >= 1)
                        {
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//span[normalize-space()='{UserName}']")).Click();
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//li[@aria-label='{UserName1}']")).Click();
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//span[normalize-space()='{ProductID}']")).Click();
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProductID1}']")).Click();
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//span[normalize-space()='{ServiceCategory}']")).Click();
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ServiceCategory1}']")).Click();
                            projectAssignmentPage.SaveButton.Click();
                            if (IsToastMessageDisplayed())
                            {
                                testCaseStatusObj.status = false;
                                projectAssignmentPage.CancelButton.Click();
                                Screenshots screenshots = new Screenshots();
                                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailureScreenshot.png");
                                SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                            }

                        }
                        else
                        {
                            testCaseStatusObj.status = false;
                            projectAssignmentPage.CancelButton.Click();
                            Screenshots screenshots = new Screenshots();
                            testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailureScreenshot.png");
                            SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Project Assignment");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailureScreenshot.png");
            }

            return testCaseStatusObj;


        }
        public TestCaseStatusObj AddProjectOwners()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                projectOwnersPage.ProjectsLink.Click();
                Thread.Sleep(1000);
                projectOwnersPage.ProjectOwnersLink.Click();
                Thread.Sleep(1000);
                List<Add_Project_Owners> addProjectOwnersList = fileObj.addprojectOwnersList;
                foreach (var Projectdata in addProjectOwnersList)
                {
                    //projectAssignmentPage.AddButton.Click();
                    WebDriverWait wait = new WebDriverWait(Browser.driver, TimeSpan.FromSeconds(10));
                    IWebElement addButton = wait.Until(ExpectedConditions.ElementToBeClickable(projectAssignmentPage.AddButton));
                    addButton.Click();
                    string ProjectName = Projectdata.Project_Name;
                    string OwnerName = Projectdata.Owner_Name;
                    string ProductID = Projectdata.Product_ID;

                    if (ProjectName.Length >= 1 && OwnerName.Length >= 1 && ProductID.Length >= 1)
                    {
                        Thread.Sleep(1000);
                        projectOwnersPage.SelectAProjectNameDropdown.Click();
                        Thread.Sleep(1000);
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProjectName}']")).Click();
                        Thread.Sleep(1000);
                        projectOwnersPage.SelectAOwnerName.Click();
                        Thread.Sleep(1000);
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{OwnerName}']")).Click();
                        Thread.Sleep(1000);
                        projectOwnersPage.SelectProductID.Click();
                        Thread.Sleep(1000);
                        Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProductID}']")).Click();
                        Thread.Sleep(2000);
                        projectOwnersPage.SaveButton.Click();
                        if (IsToastMessageDisplayed())
                        {
                            testCaseStatusObj.status = false;
                            projectOwnersPage.CancelButton.Click();
                            Screenshots screenshots = new Screenshots();
                            testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectOwnerTestFailureScreenshot.png");
                            SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        }

                    }
                    else
                    {
                        testCaseStatusObj.status = false;
                        projectOwnersPage.CancelButton.Click();
                        Screenshots screenshots = new Screenshots();
                        testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectOwnerTestFailureScreenshot.png");
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Project Owners");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectOwnersTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj ModifyProjectOwners()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Login();
                Thread.Sleep(6000);
                projectOwnersPage.ProjectsLink.Click();
                Thread.Sleep(1000);
                projectOwnersPage.ProjectOwnersLink.Click();
                Thread.Sleep(1000);
                List<Modify_Project_Owners_Edit> modifyProjectOwnersEditList = fileObj.modifyprojectOwnersEditList;
                List<Modify_Project_Owners> modifyProjectOwnersList = fileObj.modifyprojectOwnersList;
                foreach (var Projectdata in modifyProjectOwnersEditList)
                {
                    string ProjectName = Projectdata.Project_Name;
                    string OwnerName = Projectdata.Owner_Name;
                    string ProductID = Projectdata.Product_ID;


                    foreach (var Projectdata1 in modifyProjectOwnersList)
                    {
                        IWebElement editButton = Browser.driver.FindElement(By.XPath($"//tr[td[contains(., '{ProjectName}')]][td[contains(., '{OwnerName}')]][td[contains(., '{ProductID}')]]//i[@class='pi pi-pencil edit-icon']"));
                        editButton.Click();
                        string ProjectName1 = Projectdata1.Modify_Project_Name;
                        string OwnerName1 = Projectdata1.Modify_Owner_Name;
                        string ProductID1 = Projectdata1.Modify_Product_ID;

                        if (ProjectName1.Length >= 1 && OwnerName1.Length >= 1 && ProductID1.Length >= 1)
                        {
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//span[normalize-space()='{OwnerName}']")).Click();
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//li[@aria-label='{OwnerName1}']")).Click();
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//span[normalize-space()='{ProductID}']")).Click();
                            Thread.Sleep(1000);
                            Browser.driver.FindElement(By.XPath($"//li[@aria-label='{ProductID1}']")).Click();
                            Thread.Sleep(1000);
                            projectOwnersPage.SaveButton.Click();

                            if (IsToastMessageDisplayed())
                            {
                                testCaseStatusObj.status = false;
                                projectOwnersPage.CancelButton.Click();
                                Screenshots screenshots = new Screenshots();
                                testCaseStatusObj.Links = screenshots.CaptureScreenshot("ModifyProjectOwnersTestFailed.png");
                                SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                            }
                        }
                        else
                        {
                            testCaseStatusObj.status = false;
                            projectAssignmentPage.CancelButton.Click();
                            Screenshots screenshots = new Screenshots();
                            testCaseStatusObj.Links = screenshots.CaptureScreenshot("ModifyProjectOwnersTestFailed.png");
                            SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatusObj.Links).Build());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Add Project Owners");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddProjectOwnersTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }
        public TestCaseStatusObj EndToEndTesting()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                if (true)
                {
                    testCaseStatusObj = Login();
                    testCaseStatusObj = AddUsers();
                    testCaseStatusObj = AddCategoryE();
                    testCaseStatusObj = AddRoles();
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "exception");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("AddCategoryTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }

        public TestCaseStatusObj Login()
        {
            TestCaseStatusObj testCaseStatusObj = new TestCaseStatusObj();
            testCaseStatusObj.status = true;
            try
            {
                Thread.Sleep(5000);
                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string username = fileObj.genaralList.Find(u => u.Key.Equals("User Name")).Value;
                string password = fileObj.genaralList.Find(u => u.Key.Equals("Password")).Value;

                Browser.driver.FindElement(By.Id("userName")).SendKeys(username);
                Browser.driver.FindElement(By.Name("password")).SendKeys(password);
                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Browser.driver.FindElement(By.XPath("//span[text()='Login']")).Click();
                Thread.Sleep(5000);
                if (IsHomePageDisplayed())
                {
                    SampleTest.test.Log(Status.Pass, "Login was successful");
                }
                else
                {
                    testCaseStatusObj.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatusObj.Links = screenshots.CaptureScreenshot("LoginTestFailureScreenshot.png");
                    SampleTest.test.AssignAuthor("Ganesh S");
                    SampleTest.test.AssignCategory("Administration");
                    SampleTest.test.Log(Status.Fail, "Test Failed - Invalid Username or Password");
                }
            }
            catch (Exception e)
            {
                testCaseStatusObj.status = false;
                obj.LogException(e, "Validate Login");
                Screenshots screenshots = new Screenshots();
                testCaseStatusObj.Links = screenshots.CaptureScreenshot("LoginTestFailureScreenshot.png");
            }
            return testCaseStatusObj;
        }



        public bool IsValid(string value)
        {

            if (value.Length < 8 || value.Length > 50)
            {
                return false;
            }
            bool hasAlphabet = false;
            bool hasNumber = false;
            bool hasSpecialCharacter = false;
            foreach (char c in value)
            {
                if (char.IsLetter(c))
                {
                    hasAlphabet = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    hasSpecialCharacter = true;
                }
            }
            if (hasAlphabet && hasNumber && hasSpecialCharacter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsValidRoleName(string roleName)
        {
            return roleName.Length >= 1;
        }

        public bool IsValidFirstName(string firstName)
        {
            return firstName.Length >= 1;
        }
        public bool IsValidLastName(string lastName)
        {
            return lastName.Length >= 1;
        }
        private bool IsToastMessageDisplayed()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Browser.driver, TimeSpan.FromSeconds(10));
                By toastMessageLocator = By.XPath("//div[text()='Internal Server Error']");
                IWebElement toastMessage = wait.Until(ExpectedConditions.ElementIsVisible(toastMessageLocator));
                return toastMessage.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public void LogOut()
        {
            Browser.driver.FindElement(By.XPath("//span[@class='p-button-icon p-c pi pi-angle-down']")).Click();
            Browser.driver.FindElement(By.XPath("//a[@href='#']//span[text()='Log out']")).Click();
        }
        private bool IsHomePageDisplayed()
        {
            try
            {
                IWebElement logoElement = Browser.driver.FindElement(By.XPath("//a[@class='logo']"));

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void LogScreenshot(string info, string image)
        {
            //test.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }


    }
}