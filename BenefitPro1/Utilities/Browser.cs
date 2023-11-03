using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using System.IO;
using OBSWebsocketDotNet;

namespace BenefitPro1
{
    [TestClass]
    public class Browser
    {
        
        public static IWebDriver driver=null;


        public static void BrowserInit(BrowserType browserType)
        { 
          
           
            switch (browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();

                    break;

                case BrowserType.Edge:
                    driver = new EdgeDriver();

                    break;

                case BrowserType.Firefox:
                    driver = new FirefoxDriver();

                    break;
            }


            driver.Navigate().GoToUrl("http://192.168.2.12:4801/");
            driver.Manage().Window.Maximize();
            if (Browser.driver.Title.Equals("BenefitPro ™"))
            {

            }
            else
            {
                Thread.Sleep(10000);
            }



        }
        public static void BrowserDismiss()
        {
            driver.Close();
            driver.Quit();
           
        }

  
    }

    public enum BrowserType
    {
        Chrome,
        Edge,
        Firefox
    }
}


