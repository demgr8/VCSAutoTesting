using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class SeleniumDemo
    {
        public static IWebDriver _driver;

        // [OneTimeTearDown]
        //public void TearDown()
        //{
        //    _driver.Close();
        //}

        [TestCase("Sunday", TestName = "Select List Demo")]

        public static void SelectListDemo(string option)
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
            _driver.Manage().Window.Maximize();

            IWebElement DropDown = _driver.FindElement(By.Id("select-demo"));
            DropDown.Click();
            SelectElement select = new SelectElement(DropDown);
            select.SelectByText("Sunday");

            IWebElement actualResult = _driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > p.selected-value"));
            Assert.IsTrue(actualResult.Text.Contains(option), "Different");
        }

        [Test]

        public static void SingleCheckboxDemo()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();

            IWebElement singleCheckBox = _driver.FindElement(By.Id("isAgeSelected"));
            singleCheckBox.Click();

            IWebElement actutalResult = _driver.FindElement(By.Id("txtAge"));
            Assert.IsTrue(actutalResult.Text.Contains("Success"));


        }

        [Test]

        public static void MultipleCheckboxDemo() //jis turi sarasa, naudojam findelementS. Identifikuoti elementus, naudioja ciklus for, foreach
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();

            IReadOnlyCollection<IWebElement> multipleCheckBoxes = _driver.FindElements(By.ClassName("cb1-element"));

            foreach (IWebElement checkBox in multipleCheckBoxes)
            {
                if (!checkBox.Selected) //jeigu nepasekeltintas paklikint
                { 
                    checkBox.Click();
                }
            }

        }

        [Test]
        public static void MultipleCheckboxDemoButton() //nes ne button o input type
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();

            IWebElement buttonClick = _driver.FindElement(By.CssSelector("#check1"));

            if (buttonClick.GetAttribute("value").Equals("Check All"))
            {
                buttonClick.Click();
            }

          
            

        }
    
    public static void NewDemo()
        {
            //komentaras
        }
    
    }
}
