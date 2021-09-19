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

namespace VCSTestingRuduo.KlasesDarbas.PageObjectPattern
{
    class InputTest
    {
        public static IWebDriver _driver;


        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Window.Maximize();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);

            IWebElement popUp = _driver.FindElement(By.CssSelector("#at-cv-lightbox-close"));
            popUp.Click();
        }

        [OneTimeTearDown]

        //public void TearDown()
        //{
        //    _driver.Close();
        //}

        [Test]

        public static void TestInputField()
        {
            InputPage page = new InputPage(_driver);
            string text = "Penktadienis";

            page.InsertTextToPutField(text);
            page.ClickShowMessageButton();
            page.VerifyResult(text);


        }
        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a + b = Nan")]

        public static void TestSum(string firstValue, string secondValue, string expectedResult)
        {
            InputPage page = new InputPage(_driver);
            page.InsertTextToFirstInputField(firstValue);
            page.InsertTextToSecondInputField(secondValue);
            page.ClickGetTotalButton();
            page.InsertTextToFirstInputField(expectedResult);

        }

    }
}
