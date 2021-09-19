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

namespace VCSTestingRuduo.KlasesDarbas
{
    class VartuTechnika
    {
        public static IWebDriver _driver;

        [OneTimeSetUp]

        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "http://vartutechnika.lt/";
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("cookiescript_reject")).Click();
        }

        [OneTimeTearDown]

        public void TearDown()
        {
            _driver.Close();
        }


        [TestCase("2000", "2000", true, false, "Vartų kaina dabar - TIK 665.98€!", TestName = "2000 x 2000 = 665.98")]
        [TestCase("4000", "2000", true, true, "Vartų kaina dabar - TIK 1006.43€!", TestName = "4000 + 2000 = 1006.43")]
        [TestCase("4000", "2000", false, false, "Vartų kaina dabar - TIK 692.35€!", TestName = "4000 + 2000 = 692.35")]
        [TestCase("5000", "2000", false, true, "Vartų kaina dabar - TIK 989.21€!", TestName = "5000 + 2000 = 989.21")]

        public static void VartuTechnika1Test(string width, string heigth, bool automatika, bool montavimoDarbai, string answ)
        {
            IWebElement inputField1 = _driver.FindElement(By.Id("doors_width"));
            inputField1.Clear();
            inputField1.SendKeys(width);

            IWebElement inputField2 = _driver.FindElement(By.Id("doors_height"));
            inputField2.Clear();
            inputField2.SendKeys(heigth);

            IWebElement autoCheckBox = _driver.FindElement(By.Id("automatika"));
            if (automatika = !autoCheckBox.Selected)
            {
                autoCheckBox.Click();
            }

            IWebElement montavimoCheckBox = _driver.FindElement(By.Id("darbai"));
            if (montavimoDarbai = !montavimoCheckBox.Selected)
            {
                montavimoCheckBox.Click();
            }

            IWebElement showMessageButton = _driver.FindElement(By.CssSelector("#calc_submit"));
            showMessageButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(e => e.FindElement(By.CssSelector("#calc_result > div")).Displayed);

            IWebElement actualResult = _driver.FindElement(By.CssSelector("#calc_result > div"));

            Assert.IsTrue(actualResult.Text.Contains(answ), $"Result is not the same. Expected result is {answ}, but was {actualResult}");

        }


    }
}
