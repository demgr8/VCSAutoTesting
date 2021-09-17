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

       // [OneTimeTearDown]
       // public void TearDown()
      //  {
        //    _driver.Close();
       // }
    
        [TestCase("1", "5", "13", TestName = "RunningPaceCalculator")]


        public static void RunningPaceCalculator(string hours, string minutes, string distance)
        {
            IWebElement inputFieldHours = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(1) > input[type=number]"));
            inputFieldHours.SendKeys(hours);

            IWebElement inputFieldMinutes = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(2) > input[type=number]"));
            inputFieldMinutes.SendKeys(minutes);

            IWebElement inputFieldDistance = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > label > input[type=number]"));
            inputFieldDistance.SendKeys(distance);



            IWebElement kmDropDown = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span > span.selectboxit-text"));
            kmDropDown.Click();

            IWebElement km = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > ul > li.selectboxit-option.selectboxit-option-first.selectboxit-selected"));
            km.Click();

                
            ////    SelectElement selectkm = new SelectElement(kmDropDown);

            ////_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            ////selectkm.SelectByText("Kilometers");

            // IWebElement showDropDownButton = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span"));
            // showDropDownButton.Click();

            // SelectElement kmDropDown = new SelectElement(_driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span")));



            //foreach (IWebElement s in kmDropDown.Options)
            //{
            //    if(s.Text == "Kilometers")
            //    {
            //        s.Click();
            //    }
            //}






        }


    }
}
