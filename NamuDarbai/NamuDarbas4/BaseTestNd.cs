using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSTestingRuduo.KlasesDarbas.Paskaita5.Drivers;
using VCSTestingRuduo.Tools;

namespace VCSTestingRuduo.NamuDarbai.NamuDarbas4
{
    class BaseTestNd
    {
        protected static IWebDriver Driver;
        public static MultiSelectPage _multiSelectPage;

        [OneTimeSetUp]

        public static void SetUp()
        {
            Driver = CustomDriver.GetChromeDriver();
           _multiSelectPage = new MultiSelectPage(Driver);


        }

      //  [TearDown]

       // public static void TearDown()
        //{
          //  if(TestContext.CurrentContext.Result.Outcome != ResultState.Success)
          //  {
             //   MyScreenshot.TakeScreenhot(Driver);
           // }
       // }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Driver.Close();
        }
    }
}
