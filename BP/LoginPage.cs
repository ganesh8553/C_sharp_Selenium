using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
    }

    public IWebElement GetEmailTextField()
    {
        return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("userName")));
    }

    public IWebElement GetPasswordTextField()
    {
        return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("password")));
    }

    public IWebElement GetLoginButton()
    {
        return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Login']")));
    }

    public void PerformLogin(string username, string password)
    {
        GetEmailTextField().SendKeys(username);
        GetPasswordTextField().SendKeys(password);
        GetLoginButton().Click();

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
