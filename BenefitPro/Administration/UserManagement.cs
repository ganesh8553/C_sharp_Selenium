using BenefitPro.Common.BaseClass;
using BenefitPro.Common.PageObjects.Administartion;
using BenefitPro.Common.Utilities;
using ExcelDataReader;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Data;
using System.IO;
using System.Text;

namespace BenefitPro.Administration
{
    [TestFixture, Order(1)]
    public class UserManagement : BaseTest
    {
        
        public IWebDriver driver;

        //[SetUp]
        //public void SetUp()
        //{
        //    Thread.Sleep(5000);
        //  userManagementPage=new UserManagementPage(driver);
        //    userManagementPage.AdministrationLink.Click();
        //    Thread.Sleep(5000);
        //    userManagementPage.UserManagementLink.Click();
        //    Thread.Sleep(5000);

        //}


        [Test]
        public void AddUsers()
        {
            BrowserUtility browser = new BrowserUtility();
            browser.LaunchBrowser();
            Thread.Sleep(5000);
            BaseTest baseTest = new BaseTest();
            baseTest.BenefitProLogin();
            //driver.Navigate().GoToUrl("http://192.168.2.12:4801/");
            //driver.FindElement(By.Id("userName")).SendKeys("Administrator");
            //LoginPage loginPage=new LoginPage(driver);
            //loginPage.PerformLogin("Administrator", "Admin@123");
            //userManagementPage.AdministrationLink.Click();
            //Thread.Sleep(5000);
            //userManagementPage.UserManagementLink.Click();
            //Thread.Sleep(5000);


        }



        //[Test]
       
        //public void AddUsers()
        //{
        //    string directoryPath = "C:\\Users\\ganeshs\\Downloads";
        //    string excelFilePath = GetMostRecentExcelFile(directoryPath);

        //    if (string.IsNullOrEmpty(excelFilePath))
        //    {
        //        Assert.Fail("No Excel file found in the specified directory.");
        //        return;
        //    }

        //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //    using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
        //    {
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
        //            {
        //                ConfigureDataTable = (dataReader) => new ExcelDataTableConfiguration()
        //                {
        //                    UseHeaderRow = true
        //                }
        //            });

        //            DataTable dataTable = dataSet.Tables[0];

        //            foreach (DataRow row in dataTable.Rows)
        //            {
        //                string userName = row["UserName"].ToString();
        //                string password = row["Password"].ToString();
        //                string firstName = row["FirstName"].ToString();
        //                string lastName = row["LastName"].ToString();
        //                string role = row["Role"].ToString();

        //                AddUser(userName, password, firstName, lastName, role);
        //            }
        //        }
        //    }
        //}

        //public string GetMostRecentExcelFile(string directoryPath)
        //{
        //    try
        //    {
        //        string[] files = Directory.GetFiles(directoryPath, "*.xlsx")
        //                                  .Union(Directory.GetFiles(directoryPath, "*.xls"))
        //                                  .ToArray();

        //        if (files.Length == 0)
        //        {
        //            return null;
        //        }

        //        string mostRecentFile = files.OrderByDescending(f => File.GetLastWriteTime(f)).FirstOrDefault();

        //        return mostRecentFile;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //        return null;
        //    }
        //}

        //public void AddUser(string userName, string password, string firstName, string lastName, string role)
        //{
        //    Thread.Sleep(3000);
        //    userManagementPage.AddButton.Click();
        //    Thread.Sleep(3000);
        //    userManagementPage.NativeDirectory.Click();
        //    if (userName.Length < 8)
        //    {
        //        userManagementPage.PasswordInput.SendKeys(password);
        //        TakeScreenshot($"UsernameTooShort_{userName}");
        //        userManagementPage.CancelButton.Click();
        //        return;
        //    }

        //    bool passwordError = !HasSpecialCharacter(password);

        //    if (passwordError)
        //    {
        //        userManagementPage.FirstNameInput.SendKeys(firstName);
        //        TakeScreenshot($"PasswordWithoutSpecialChar_{userName}");
        //        userManagementPage.CancelButton.Click();
        //        return;
        //    }


        //    userManagementPage.AddButton.Click();


        //    userManagementPage.UserNameInput.SendKeys(userName);
        //    userManagementPage.PasswordInput.SendKeys(password);
        //    userManagementPage.FirstNameInput.SendKeys(firstName);
        //    userManagementPage.LastNameInput.SendKeys(lastName);
        //    userManagementPage.Checkbox.Click();
        //    userManagementPage.RoleDropdown.Click();
        //    userManagementPage.TesterRoleOption.Click();
        //    userManagementPage.SaveButton.Click();
        //    Thread.Sleep(5000);

        //}

        //private bool HasSpecialCharacter(string password)
        //{
        //    string specialCharacters = @"!@#$%^&*()-_=+[]{}|;:,.<>?";
        //    return password.Intersect(specialCharacters).Any();
        //}

        //public void TakeScreenshot(string screenshotName)
        //{
        //   ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
        //    Screenshot screenshot = screenshotDriver.GetScreenshot();
        //    string screenshotFilePath = $"C:\\Users\\ganeshs\\Pictures\\Screenshot\\{screenshotName}.png";
        //    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
        //    TestContext.AddTestAttachment(screenshotFilePath);
        //}

    }
}

