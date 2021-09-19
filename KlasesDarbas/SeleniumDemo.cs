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
    class SeleniumDemo
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

            IWebElement button = _driver.FindElement(By.CssSelector("#check1"));

            if (button.GetAttribute("value").Equals("Check All"))
            {
                button.Click();
            }



        }

        [Test]
        public static void TestSingleInputField()
        {
            //pakelia browser
            IWebDriver driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Window.Maximize();

            //susiranda web elementa
            IWebElement inputField = _driver.FindElement(By.Id("user-message"));

            //testas kuris bus irasomas i inputField
            string myText = "Hello";

            //iraso texta i input field
            inputField.SendKeys(myText);

            //popUt idendifikacija
            IWebElement popUp = _driver.FindElement(By.CssSelector("#at-cv-lightbox-close"));
            popUp.Click();

            //copy -> copy selector = get input > button
            IWebElement showMessageButton = _driver.FindElement(By.CssSelector("#get-input > button"));

            //paspaudzia
            showMessageButton.Click();

            //identifikiuojan acualt result elementus
            IWebElement actualResultText = _driver.FindElement(By.Id("display"));

            //tikrinam Expected vs Actual
            // Assert.AreEqual(myText, actualResultText.Text, "Text is different");   vienodi
            Assert.IsTrue(actualResultText.Text.Contains(myText), "Text is different");

            _driver.Quit(); //uzdaro narsykle


        }

        [Test]

        public static void RadioButtonDemo()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
            _driver.Manage().Window.Maximize();



            IWebElement radio = _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[2]/label[2]/input"));
            radio.Click();

            IWebElement radioButton = _driver.FindElement(By.Id("buttoncheck"));
            radioButton.Click();

            IWebElement result = _driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > p.radiobutton"));

            Assert.IsTrue(result.Text.Contains("Radio button 'Female' is checked"), "WRONG");


        }

        [Test]
        public static void GroupRadioButtonsDemo()
        {
            string answer = "Sex : Male\r\nAge group: 0 - 5";

            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-radiobutton-demo.html";
            _driver.Manage().Window.Maximize();

            IWebElement radio1 = _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/div[1]/label[1]/input"));
            radio1.Click();

            IWebElement radio2 = _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/div[2]/label[1]/input"));
            radio2.Click();

            IWebElement GroupradioButton = _driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > button"));
            GroupradioButton.Click();

            Assert.That(_driver.FindElement(By.CssSelector(".groupradiobutton")).Text, Is.EqualTo(answer));



        }
    }
}