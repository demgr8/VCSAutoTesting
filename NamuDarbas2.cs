using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class NamuDarbas2
    {
        public static IWebDriver _driver;

        [TearDown] //po visu testu o ne po vieno
         public void TearDown()
          {
            _driver.Close();
         }

        [TestCase("Chrome", "Chrome 93 on Windows 10", TestName = "Chrome")]
        [TestCase("FireFox", "Firefox 92 on Windows 10", TestName = "FireFox")]

        public static void DifferentBrowsers(string browser, string actulatResult)
        {

            switch (browser)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
                    _driver.Manage().Window.Maximize();

                    IWebElement actualResult = _driver.FindElement(By.CssSelector("#primary-detection > div"));
                    Assert.IsTrue(actualResult.Text.Contains(actulatResult), "Browser is different");
                    break;

                case "FireFox":
                    _driver = new FirefoxDriver();
                    _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
                    _driver.Manage().Window.Maximize();

                    actualResult = _driver.FindElement(By.CssSelector(".simple-major"));
                    Assert.IsTrue(actualResult.Text.Contains(actulatResult), "Browser is different");
                    break;
            }
        }
    }
}
