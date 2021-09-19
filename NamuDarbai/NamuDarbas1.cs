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

namespace VCSTestingRuduo.NamuDarbai
{
    class NamuDarbas1
    {
        public static IWebDriver _driver;

        [OneTimeSetUp]

        public void SetUp() //naudojama tam kas kartojasi
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Window.Maximize();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);

            IWebElement popUp = _driver.FindElement(By.CssSelector("#at-cv-lightbox-close"));
            popUp.Click();
        }


        [OneTimeTearDown]//po visu testu uzdarys browser 

        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase("2", "2", "4", "-5", "3", -2, TestName = "2 + 2 = 4, -5 + 3 = -2")]  //nurodom kintamuosius
        [TestCase("a", "b", "NaN", TestName = "a + b = Nan")]

        public static void TwoInputFieldsTest1AndTest2(string num1, string num2, string answer, string number1, string number2, int answ) //perduodam kintamuosius is metodo
        {

            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            inputField1.SendKeys(num1);

            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            inputField2.SendKeys(num2);

            IWebElement showMessageButton = _driver.FindElement(By.CssSelector("#gettotal > button"));

            showMessageButton.Click();

            IWebElement actualResultNumber = _driver.FindElement(By.Id("displayvalue"));

            Assert.IsTrue(actualResultNumber.Text.Contains(answer), "Number is different");

            inputField1.Clear();
            inputField2.Clear();

            inputField1.SendKeys(number1);
            inputField2.SendKeys(number2);

            IWebElement showMessageButton2 = _driver.FindElement(By.CssSelector("#gettotal > button"));

            showMessageButton2.Click();

            IWebElement actualResultNumber2 = _driver.FindElement(By.Id("displayvalue"));

            Assert.IsTrue(actualResultNumber2.Text.Contains("" + answ), "Number is different");


        }

        [Test]

        public static void TwoInputFieldsTest3()
        {

            string myText1 = "a";
            string myText2 = "b";
            string answ = "NaN";

            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            inputField1.SendKeys(myText1);

            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            inputField2.SendKeys(myText2);

            IWebElement showMessageButton = _driver.FindElement(By.CssSelector("#gettotal > button"));
            showMessageButton.Click();

            IWebElement actualResultAnswer = _driver.FindElement(By.Id("displayvalue"));

            Assert.IsTrue(actualResultAnswer.Text.Contains(answ), "Answer is different");
        }


    }
}
