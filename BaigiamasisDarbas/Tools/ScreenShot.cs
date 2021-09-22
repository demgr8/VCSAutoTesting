using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.BaigiamasisDarbas.Tools
{
    public class ScreenShot
    {
        public static void TakeScreenhot(IWebDriver driver)
        {
            Screenshot screenshot = driver.TakeScreenshot();

            string projecttDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string screenshotDirectory = Path.GetFullPath(Path.Combine(projecttDirectory, @"..\..\"));

            string screenshotFolder = Path.Combine(screenshotDirectory, "Screenshot");
            Directory.CreateDirectory(screenshotFolder);

            string screenshotName = $"{TestContext.CurrentContext.Test.Name} {DateTime.Now:HH_mm_ss}.png";
            string screenshotPath = Path.Combine(screenshotFolder, screenshotName);

            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        }
    }
}
