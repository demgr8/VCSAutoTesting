using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.BaigiamasisDarbas.Drivers
{
    public class CustomDriver
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browsers.Chrome);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            return GetDriver(Browsers.FireFox);
        }

        public static IWebDriver GetIncogdinotChromeDriver()
        {
            return GetDriver(Browsers.IncognitoChrome);
        }

        private static IWebDriver GetDriver(Browsers browserName)
        {
            IWebDriver webDriver = null;

            switch (browserName)
            {
                case Browsers.Chrome:
                    webDriver = new ChromeDriver();
                    break;
                case Browsers.FireFox:
                    webDriver = new FirefoxDriver();
                    break;
                case Browsers.IncognitoChrome:
                    webDriver = GetChromeWithIncognitoOption();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }

            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           
            return webDriver;
        }

        private static IWebDriver GetChromeWithIncognitoOption()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            return new ChromeDriver(options);
        }
    }
}
