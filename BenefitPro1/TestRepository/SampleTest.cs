using System.Text.RegularExpressions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BenefitPro1.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WindowsInput;
using Keys = OpenQA.Selenium.Keys;

namespace BenefitPro1.TestRepository
{

    [TestClass]
    public class SampleTest : BaseTest
    {
        public IWebDriver driver;
        static ExcelData excelData = new ExcelData();
        FileObj fileObj = excelData.ReadExcel("");
        GenerateFile obj = new GenerateFile();

        public ExtentReports extent = null;
        public static ExtentTest test = null;
        public static ExtentHtmlReporter htmlReporter = null;
        public string tempFilePath;

        public static string finalFilePath;
        public SampleTest(ExtentReports extent)
        {
            this.extent = extent;
        }

        public SampleTest()
        {

        }

        public void BeforeTest()
        {

        }

        public void AfterTest()
        {
            Browser.BrowserDismiss();

        }
        [TestMethod]
        public TestCaseStatusObj End_To_End_Testing()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //  Report();
                test = extent.CreateTest("End To End Testing ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = EndToEndTesting();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "End To End  Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        test.Log(Status.Fail, "Test Failed - End To End  Test is Failed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");
                    }

                }
                else
                {
                    testCaseStatus.status = false;

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "End To End");
            }

            return testCaseStatus;
        }

        [TestMethod]

        public TestCaseStatusObj Validate_Login()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;


            try
            {
                test = extent.CreateTest("Validate_Login").Info("Test Started");

                Thread.Sleep(5000);
                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                string username = fileObj.genaralList.Find(u => u.Key.Equals("User Name")).Value;
                string password = fileObj.genaralList.Find(u => u.Key.Equals("Password")).Value;
                if (!IsValidUsername(username) && !IsValidPassword(password))
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginTestFailureScreenshot.png");
                    test.Log(Status.Fail, "Validation Failed - Invalid Username or Password");
                    test.Log(Status.Fail, testCaseStatus.Links);
                    return testCaseStatus;
                }
                Browser.driver.FindElement(By.Id("userName")).SendKeys(username);
                Browser.driver.FindElement(By.Name("password")).SendKeys(password);
                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Browser.driver.FindElement(By.XPath("//span[text()='Login']")).Click();
                Thread.Sleep(5000);

                if (IsHomePageDisplayed())
                {
                    Browser.driver.FindElement(By.XPath("//span[@class='p-button-icon p-c pi pi-angle-down']")).Click();
                    Browser.driver.FindElement(By.XPath("//a[@href='#']//span[text()='Log out']")).Click();
                    test.AssignAuthor("Ganesh S");
                    test.AssignCategory("Administration");
                    Screenshots screenshots = new Screenshots();
                    test.Log(Status.Pass, "Login Page Test is  Passed");


                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginTestFailureScreenshot.png");
                    test.AssignAuthor("Ganesh S");
                    test.AssignCategory("Administration");
                    test.Log(Status.Fail, "Test Failed - Invalid Username or Password");
                    SampleTest.test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatus.Links).Build());

                }

            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Validate Login");
                Screenshots screenshots = new Screenshots();
                testCaseStatus.Links = screenshots.CaptureScreenshot("LoginTestFailureScreenshot.png");

                test.Log(Status.Fail, "Test Failed");
                test.Log(Status.Fail, e.ToString());
                test.Log(Status.Fail, testCaseStatus.Links);
                throw;
            }


            return testCaseStatus;
        }

        private bool IsValidUsername(string username)
        {
            return username.Length >= 8 && username.Length <= 20;
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 8 && password.Length <= 50 &&
                   Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$");
        }

        [TestMethod]
        public TestCaseStatusObj Add_Users()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                Actions actions = new Actions(Browser.driver);

                actions.KeyDown(Keys.Control).KeyDown(Keys.Alt).SendKeys("r").KeyUp(Keys.Control).KeyUp(Keys.Alt).Build().Perform();
                Thread.Sleep(3000);
                test = extent.CreateTest("Add Users").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddUsers();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "UserManagementPage Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddUserScreenshot.png");
                        test.Log(Status.Fail, "Test Failed - UserManagement Test is Failed");
                    }
                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("AddUsersScreenshot.png");
                    test.AssignCategory("Administration");
                    test.Log(Status.Fail, "Test Failed - UserManagement Page Test is Failed");
                    test.Log(Status.Fail, testCaseStatus.Links);

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Add Users");
            }

            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Add_Roles()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //Report();
                test = extent.CreateTest("Add Roles ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddRoles();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "RoleManagement Page Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddRolesScreenshot.png");
                        test.Log(Status.Fail, "Test Failed - RoleManagement Test is Failed");
                        test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatus.Links).Build());

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - RoleManagement  Test is Failed");
                    test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatus.Links).Build());
                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Add Roles");
            }
            //finally
            //{
            //    ReportFilePath();
            //}
            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Add_Service()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //  Report();
                test = extent.CreateTest("Add Service ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddService();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Management Page Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddServiceScreenshot.png");
                        test.Log(Status.Fail, "Screenshot:", MediaEntityBuilder.CreateScreenCaptureFromBase64String(testCaseStatus.Links).Build());
                        test.Log(Status.Fail, "Test Failed - Management Test is Failed");

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - Management  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Add Service");
            }
            //finally
            //{
            //    ReportFilePath();
            //}
            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Add_Category()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //  Report();
                test = extent.CreateTest("Add Category ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddCategory();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Management Page Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        //Screenshots screenshots = new Screenshots();
                        //testCaseStatus.Links = screenshots.CaptureScreenshot("AddCategoryScreenshot.png");
                        test.Log(Status.Fail, "Test Failed - Management Test is Failed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.AssignAuthor("Ganesh S");
                    test.AssignCategory("Administration");
                    test.Log(Status.Fail, "Test Failed - Management  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Add Category");
            }

            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Add_Project()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //  Report();
                test = extent.CreateTest("Add Project ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddProject();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Management Page Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        test.Log(Status.Fail, "Test Failed - Management Test is Failed");

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - Management  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Add Project");
            }
            //finally
            //{
            //    ReportFilePath();
            //}
            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Add_Product()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //  Report();
                test = extent.CreateTest("Add Product ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddProduct();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Management Page Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        //Screenshots screenshots = new Screenshots();
                        //testCaseStatus.Links = screenshots.CaptureScreenshot("AddCategoryScreenshot.png");
                        test.Log(Status.Fail, "Test Failed - Management Test is Failed");

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - Management  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Add Product");
            }
            //finally
            //{
            //    ReportFilePath();
            //}
            return testCaseStatus;
        }

        [TestMethod]
        public TestCaseStatusObj Add_Benchmark_Manual()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                // Report();
                test = extent.CreateTest("Add Benchmark Manual ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddBenchmarkManual();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Add Benchmark Manual Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddBenchmarkManualTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - BenchmarkManagement Test is Failed");

                    }
                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - BenchmarkManagement  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Add Roles");
            }
            //finally
            //{
            //    //testCaseStatus.Links1 = ReportFilePath();
            //}
            return testCaseStatus;
        }

        [TestMethod]
        public TestCaseStatusObj Add_Benchmark_From_File()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //Report();
                test = extent.CreateTest("Add Benchmark From File ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddBenchmarkFromFile();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Add Benchmark From File is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddBenchmarkFromFileTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - BenchmarkManagement Test is Failed");
                        test.Log(Status.Fail, "Benchmark Name is Required");
                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - BenchmarkManagement  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Add Benchmark");
            }
            //finally
            //{
            //    testCaseStatus.Links1 = ReportFilePath();
            //}
            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Add_Benchmark_Sample_EDI_File()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //Report();
                test = extent.CreateTest("Add Benchmark Sample EDI  File ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddBenchmarkSampleEdiFile();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Add Benchmark Sample EDI  File is Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddBenchmarkSampleEDIFileTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - BenchmarkManagement Test is Failed");
                        test.Log(Status.Fail, "Provide correct EDI file path");
                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - BenchmarkManagement  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Benchmark");
            }
            //finally
            //{
            //    testCaseStatus.Links1 = ReportFilePath();
            //}
            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Upload_Claims_From_File()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //Report();
                test = extent.CreateTest("Upload  Claims From File  ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = UploadClaimsFromFile();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Upload Claims From File Test is Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddBenchmarkSampleEDIFileTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - BenchmarkManagement Test is Failed");

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - BenchmarkManagement  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Benchmark");
            }

            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Add_Claims_Manually()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;

            try
            {
                //Report();

                test = extent.CreateTest("Upload  Claims From File  ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddClaimsManually();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Upload Claims From File Test is Passed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddBenchmarkSampleEDIFileTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - BenchmarkManagement Test is Failed");

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - BenchmarkManagement  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Benchmark");
            }


            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Accumulator_Mapping()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;

            try
            {
                test = extent.CreateTest("Upload  Claims From File  ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AccumulatorMapping();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Accumulator Mapping  Test is Passed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AccumulatorMappingTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - Accumulator Mapping Test is Failed");

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.Log(Status.Fail, "Test Failed - Accumulator Mapping  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Benchmark");
            }


            return testCaseStatus;
        }

        [TestMethod]
        public TestCaseStatusObj Process_Benefit()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //  Report();
                test = extent.CreateTest("Process Benefit ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = ProcessBenefit();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Process Benefit Page Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        //Screenshots screenshots = new Screenshots();
                        //testCaseStatus.Links = screenshots.CaptureScreenshot("AddCategoryScreenshot.png");
                        test.Log(Status.Fail, "Test Failed - Process Benefit Test is Failed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.AssignAuthor("Ganesh S");
                    test.AssignCategory("Administration");
                    test.Log(Status.Fail, "Test Failed - Process Benefit  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Add Category");
            }

            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj BenefitLoad_ImportBenefits()
        {

            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //  Report();
                test = extent.CreateTest("Process Claim ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = BenefitLoad_Import_Benefits();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Process Claim Page Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        //Screenshots screenshots = new Screenshots();
                        //testCaseStatus.Links = screenshots.CaptureScreenshot("AddCategoryScreenshot.png");
                        test.Log(Status.Fail, "Test Failed - Process Claim Test is Failed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");

                    }
                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.AssignAuthor("Ganesh S");
                    test.AssignCategory("Administration");
                    test.Log(Status.Fail, "Test Failed - Process Claim  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Process Claim");
            }
            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Process_Claim()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //  Report();
                test = extent.CreateTest("Process Claim ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = ProcessClaim();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Process Claim Page Test is  Passed");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        //Screenshots screenshots = new Screenshots();
                        //testCaseStatus.Links = screenshots.CaptureScreenshot("AddCategoryScreenshot.png");
                        test.Log(Status.Fail, "Test Failed - Process Claim Test is Failed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");

                    }
                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("LoginFailedScreenshot.png");
                    test.AssignAuthor("Ganesh S");
                    test.AssignCategory("Administration");
                    test.Log(Status.Fail, "Test Failed - Process Claim  Test is Failed");

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Process Claim");
            }

            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Add_Project_Assignment()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;

            try
            {
                //Report();

                test = extent.CreateTest("Add Project Assignment ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddProjectAssignment();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Add Project Assignment Test is Passed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - AddProjectAssignment Test is Failed");
                        test.Log(Status.Fail);
                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("AddProjectAssignmentTestFailed.png");
                    test.Log(Status.Fail, "Test Failed - Project Assignment  Test is Failed");
                    test.Log(Status.Fail);
                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Project Assignment ");
            }


            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Modify_Project_Assignment()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //Report();
                test = extent.CreateTest("Modify Project Assignment ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = ModifyProjectAssignment();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Modify Project Assignment Test is Passed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("ModifyProjectAssignmentTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - ModifyProjectAssignment Test is Failed");
                        test.Log(Status.Fail);
                    }
                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("ModifyProjectAssignmentTestFailed.png");
                    test.Log(Status.Fail, "Test Failed - Project Assignment  Test is Failed");
                    test.Log(Status.Fail).AddScreenCaptureFromPath("");
                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Project Assignment ");
            }
            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Add_Project_Owners()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //Report();

                test = extent.CreateTest("Add Project Owners ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = AddProjectOwners();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Add Project Owners Test is Passed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("AddProjectOwnersTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - AddProjectOwners Test is Failed").Fail("Screenshot: ", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshots.screenshotFilePath).Build());
                        test.Log(Status.Fail).AddScreenCaptureFromPath("C:\\Ganesh\\C# selenium\\Screenshot\\AddProjectOwnersTestFailed.png");
                    }
                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("AddProjectOwnersTestFailed.png");
                    test.Log(Status.Fail, "Test Failed - AddProjectOwners Test is Failed");
                    test.Log(Status.Fail).AddScreenCaptureFromBase64String(screenshots.CaptureScreenshot("fail"));
                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Project Owners ");
            }
            return testCaseStatus;
        }
        [TestMethod]
        public TestCaseStatusObj Modify_Project_Owners()
        {
            TestCaseStatusObj testCaseStatus = new TestCaseStatusObj();
            testCaseStatus.status = true;
            try
            {
                //Report();

                test = extent.CreateTest("Modify Project Owners ").Info("Test Started");
                if (Browser.driver.Title.Equals("BenefitPro ™"))
                {
                    testCaseStatus = ModifyProjectOwners();
                    if (testCaseStatus.status)
                    {
                        test.Log(Status.Pass, "Modify Project Owners Test is Passed");
                        test.AssignAuthor("Ganesh S");
                        test.AssignCategory("Administration");
                    }
                    else
                    {
                        testCaseStatus.status = false;
                        Screenshots screenshots = new Screenshots();
                        testCaseStatus.Links = screenshots.CaptureScreenshot("ModifyProjectOwnersTestFailed.png");
                        test.Log(Status.Fail, "Test Failed - ModifyProjectOwners Test is Failed").Fail("Screenshot: ", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshots.screenshotFilePath).Build());
                        test.Log(Status.Fail).AddScreenCaptureFromPath("C:\\Ganesh\\C# selenium\\Screenshot\\ModifyProjectOwnersTestFailed.png");

                    }

                }
                else
                {
                    testCaseStatus.status = false;
                    Screenshots screenshots = new Screenshots();
                    testCaseStatus.Links = screenshots.CaptureScreenshot("ModifyProjectOwnersTestFailed.png");
                    test.Log(Status.Fail, "Test Failed - ModifyProjectOwners Test is Failed");
                    test.Log(Status.Fail).AddScreenCaptureFromBase64String(screenshots.CaptureScreenshot("fail"));

                }
            }
            catch (Exception e)
            {
                testCaseStatus.status = false;
                obj.LogException(e, "Project Owners ");
            }
            return testCaseStatus;
        }
        public TestCaseStatusObj AfterTestCatchException()
        {
            throw new NotImplementedException();
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

    }
}

