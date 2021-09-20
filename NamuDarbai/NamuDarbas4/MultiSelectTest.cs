using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.NamuDarbai.NamuDarbas4
{
    class MultiSelectTest
    {
        private static MultiSelectPage _page;
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _page = new MultiSelectPage(_driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }

        [Test]

        public void MultiDropDownFirstSelectedTestTwoValues()
        {
            _page.NavigateToDefaultPage().ClickOnTwoMultiDropDownElementByValue("Washington", "Texas").
                ClickFirstSelectedButton().VerifyMiultiSelectValueContains("Texas");
        }

        [Test]
        public void MultiDropDownGetAllSelectedTestTwoValues()
        {
            _page.NavigateToDefaultPage().ClickOnTwoMultiDropDownElementByValue("Ohio", "Florida").
                GetAllSelectedButton().VerifyMiultiSelectValueContains("Ohio,Florida");
        }

        [Test]
        public void MultiDropDownFirstSelectedTestThreeValues()
        {
            _page.NavigateToDefaultPage().ClickOnThreeMultiDropDownElementByValue ("New Jersey", "Pennsylvania", "Texas").
                GetAllSelectedButton().VerifyMiultiSelectValueContains("Texas");
        }

        [Test]
        public void MultiDropDownGetAllSelectedTestFourValues()
        {
            _page.NavigateToDefaultPage().ClickOnFourMultiDropDownElementByValue("California", "New Jersey", "Ohio", "Pennsylvania").
                GetAllSelectedButton().VerifyMiultiSelectValueContains("California,New Jersey,Ohio,Pennsylvania");
        }
    }
}
