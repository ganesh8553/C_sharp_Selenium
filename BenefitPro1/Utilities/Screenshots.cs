//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using OpenQA.Selenium;

//namespace BenefitPro1.Utilities
//{
//    public class Screenshots
//    {
//        private static int screenshotCounter = 1;
//        public readonly IWebDriver driver;
//        public string screenshotFilePath;

       

//        public string CaptureScreenshot(string screenshotFileName)
//        {
//            ITakesScreenshot takesScreenshot = (ITakesScreenshot)Browser.driver;
          
//            Screenshot screenshot = takesScreenshot.GetScreenshot();
//                string currentDirectory = "C:\\Ganesh\\C# selenium\\Screenshot";
//                 string uniqueScreenshotFileName = $"{screenshotFileName}_{screenshotCounter}.png";
//            screenshotFilePath = Path.Combine(currentDirectory, uniqueScreenshotFileName);
//                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
//                screenshotCounter++;
//                return screenshotFilePath;
            
//            //return null;
//        }

//    }
//}
using System;
using System.IO;
using OpenQA.Selenium;

namespace BenefitPro1.Utilities
{
    public class Screenshots
    {
        private static int screenshotCounter = 1;
        public readonly IWebDriver driver;
        public string screenshotFilePath;

        
        public string CaptureScreenshot(string screenshotFileName)
        {
            try
            {
                ITakesScreenshot takesScreenshot = (ITakesScreenshot)Browser.driver;
                Screenshot screenshot = takesScreenshot.GetScreenshot();

                using (MemoryStream memoryStream = new MemoryStream(screenshot.AsByteArray))
                {
                    string base64Screenshot = Convert.ToBase64String(memoryStream.ToArray());

                    string currentDirectory = "C:\\Ganesh\\C# selenium\\Screenshot";
                    string uniqueScreenshotFileName = $"{screenshotFileName}_{screenshotCounter}.png";
                    screenshotFilePath = Path.Combine(currentDirectory, uniqueScreenshotFileName);
                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
                    screenshotCounter++;
                    return base64Screenshot;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error capturing screenshot and converting to Base64: {ex.Message}");
                return null;             }
        }
    }
}
