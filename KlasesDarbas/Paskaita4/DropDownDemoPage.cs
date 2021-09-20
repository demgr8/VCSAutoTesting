using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.KlasesDarbas.Paskaita4
{
    public class DropDownDemoPage : BasePage
    {

        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultTextStatic = "Day selected :- ";

        private SelectElement _dropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));


        IWebElement _resultText => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > p.selected-value"));

        private SelectElement _multiDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));

        private IWebElement _firstSelectedButton => Driver.FindElement(By.Id("printMe"));

        private IWebElement _getAllSelectedButton => Driver.FindElement(By.Id("printAll"));

        private IWebElement _multiDropDownResult => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > p.getall-selected"));

        public DropDownDemoPage(IWebDriver webDriver): base(webDriver) //konstruktorius
        {
            //tuscias konstruktorius
        }

        public DropDownDemoPage NavigateToDefaultPage()  //kitas apsirasymo budas
        {
            Driver.Url = PageAddress;

            return this;
        }

        public DropDownDemoPage SelectFromDropDownByText(string text)
        {
            _dropDown.SelectByText(text);

            return this;
        }

        public DropDownDemoPage SelectFromDropDownByValue(string text)
        {
            _dropDown.SelectByValue(text);

            return this;
        }

        public DropDownDemoPage VerifyResult(string expectedResult)
        {
            Assert.AreEqual(ResultTextStatic + expectedResult, _resultText.Text, $"Result is wrong not {expectedResult}");
            
            return this;
        }

        public DropDownDemoPage ClickFirstSelectedButton()
        {
            _firstSelectedButton.Click();

            return this;
        }

        public DropDownDemoPage GetAllSelectedButton()
        {
            _getAllSelectedButton.Click();

            return this;
        }

        public DropDownDemoPage ClickOnMultiDropDownElementByValue(string firstValue, string secondValue)
        {

            Actions action = new Actions(Driver);    //yra pageup pagedown cia scroll
            _multiDown.SelectByValue(firstValue);
            action.KeyDown(Keys.LeftControl); //ispaudzia ir laiko
            _multiDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);  //atleidzia
            action.Build().Perform();  //visada turi buti

            return this;
        }

        public DropDownDemoPage VerifyMiultiSelectValueContains(string expectedValue)
        {
            Assert.IsTrue(_multiDropDownResult.Text.Contains(expectedValue), "Actual value is wrong");

            return this;

        }

    }
}
