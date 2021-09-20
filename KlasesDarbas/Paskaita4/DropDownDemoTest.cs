using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.KlasesDarbas.Paskaita4
{
    class DropDownDemoTest
    {
        private static DropDownDemoPage _page;
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _page = new DropDownDemoPage(_driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }
    
        [Test]

        public void TestDropDown()
        {
            _page.NavigateToDefaultPage().SelectFromDropDownByValue("Monday").VerifyResult("Monday");
        }

        [Test]
        public void TestDropDownMultiple()
        {
            _page.NavigateToDefaultPage().ClickOnMultiDropDownElementByValue("Florida", "New York").
                GetAllSelectedButton().VerifyMiultiSelectValueContains("New York");
        }
    }
}
