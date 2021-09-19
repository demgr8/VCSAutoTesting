using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSRuduo.NamuDarbas3.Page;

namespace VCSRuduo.NamuDarbas3.Tests
{
    public class inputTestNd
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
            inputPageNd page = new inputPageNd(_driver);

            page.ClickSingleChexkBoxButton();
            page.VerifySingleCheckBoxResult();

            page.SelectAllCheckBoxes();
            page.VerifyResultUncheckAll();
            page.ClickMultipleChexkBoxButton();
            page.VerifyResultIfAllChechBoxesAreUnChecked();
        }
    }
}
