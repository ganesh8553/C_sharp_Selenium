using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPage
{
    public IWebDriver driver;
  public  WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        Thread.Sleep(2000);
       // wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
    }

    //public IWebElement GetEmailTextField()
    //{
    //     Thread.Sleep(2000);
    //    return driver.FindElement(By.Id("userName"));
    //}

    //public IWebElement GetPasswordTextField()
    //{
    //     Thread.Sleep(2000);
    //    return driver.FindElement(By.Name("password"));
    //}

    //public IWebElement GetLoginButton()
    //{
    //     Thread.Sleep(2000);
    //    return driver.FindElement(By.XPath("//span[text()='Login']"));
    //}

    public void PerformLogin()
    {
        driver.FindElement(By.Id("userName")).SendKeys("Administrator");
        driver.FindElement(By.Name("password")).SendKeys("Admin@123");
        driver.FindElement(By.XPath("//span[text()='Login']")).Click();

        if (!IsLoginSuccessful())
        {
            Assert.Fail("Login failed: Invalid username or password.");
        }
    }

    private bool IsLoginSuccessful()
    {
        string expectedPageTitle = "BenefitPro ™";
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(expectedPageTitle));

        string actualPageTitle = driver.Title;
        return actualPageTitle.Contains(expectedPageTitle);
    }
}
