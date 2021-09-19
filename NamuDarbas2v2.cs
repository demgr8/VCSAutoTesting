using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class NamuDarbas2v2
    {
        public static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.active.com/fitness/calculators/pace";
            _driver.Manage().Window.Maximize();

        }

         [OneTimeTearDown]
         public void TearDown()
          {
            _driver.Close();
         }

        [TestCase("1", "5", "13", "05", TestName = "RunningPaceCalculator")]


        public static void RunningPaceCalculator(string hours, string minutes, string distance, string answer)
        {
            IWebElement inputFieldHours = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(1) > input[type=number]"));
            inputFieldHours.SendKeys(hours);

            IWebElement inputFieldMinutes = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(2) > input[type=number]"));
            inputFieldMinutes.SendKeys(minutes);

            IWebElement inputFieldDistance = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > label > input[type=number]"));
            inputFieldDistance.SendKeys(distance);


            IWebElement kmDropDown = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span > span.selectboxit-text"));
            kmDropDown.Click();
            _driver.FindElement(By.XPath("/html/body/div[6]/div[5]/div[3]/div/div/div[2]/div/div/div[1]/div/form/div[3]/div/span/ul/li[1]")).Click();

            IWebElement perkmDropDown = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span"));
            perkmDropDown.Click();
            _driver.FindElement(By.XPath("/html/body/div[6]/div[5]/div[3]/div/div/div[2]/div/div/div[1]/div/form/div[4]/div/span/ul/li[1]")).Click();

            IWebElement calculateButton = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(6) > div > a"));
            calculateButton.Click();

             IWebElement acctualResult = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > label:nth-child(2) > input[type=number]"));
             Assert.IsTrue(acctualResult.Text.Contains(answer), "Answer is wrong");

        }

    }
}
