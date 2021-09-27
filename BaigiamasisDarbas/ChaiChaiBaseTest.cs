using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSTestingRuduo.BaigiamasisDarbas.Drivers;
using VCSTestingRuduo.BaigiamasisDarbas.Tools;

namespace VCSTestingRuduo.BaigiamasisDarbas
{
    public class ChaiChaiBaseTest
    {
        protected static IWebDriver Driver;

        public static ChaiChaiPage _chaiChaiPage;


        [SetUp]
        public static void SetUp()
        {
            Driver = CustomDriver.GetChromeDriver();
            _chaiChaiPage = new ChaiChaiPage(Driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenShot.TakeScreenshot(Driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Driver.Close();
        }
    }
}
