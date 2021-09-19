using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.NamuDarbai.NamuDarbas3
{
    class InputTestNd
    {

        public static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]

        public void TearDown()
        {
            _driver.Close();
        }

        [Test]

        public static void TestCheckBoxes()
        {
            InputPageNd page = new InputPageNd(_driver);

            page.ClickSingleChexkBoxButton();
            page.VerifySingleCheckBoxResult();

            page.SelectAllCheckBoxes();
            page.VerifyResultUncheckAll();
            page.ClickMultipleChexkBoxButton();
            page.VerifyResultIfAllChechBoxesAreUnChecked();
        }
    }
}
