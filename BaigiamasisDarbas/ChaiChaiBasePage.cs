using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.BaigiamasisDarbas
{
    public class ChaiChaiBasePage
    {
        protected static IWebDriver Driver;

        public ChaiChaiBasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }
        public void CloseBrowser()
        {
            Driver.Quit();
        }

        public WebDriverWait GetWait(int seconds = 5)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }
    }
}
