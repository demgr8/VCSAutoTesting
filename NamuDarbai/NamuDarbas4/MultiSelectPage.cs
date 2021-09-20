using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.NamuDarbai.NamuDarbas4
{
    public class MultiSelectPage : BasePageNd
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";

        private SelectElement _multiDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));

        private IWebElement _firstSelectedButton => Driver.FindElement(By.Id("printMe"));

        private IWebElement _getAllSelectedButton => Driver.FindElement(By.Id("printAll"));

        private IWebElement _multiDropDownResult => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > p.getall-selected"));

        public MultiSelectPage(IWebDriver webDriver) : base(webDriver)
        {
           
        }

        public MultiSelectPage NavigateToDefaultPage()
        {
            Driver.Url = PageAddress;
            return this;
        }

        public MultiSelectPage ClickFirstSelectedButton()
        {
            _firstSelectedButton.Click();
            return this;
        }

        public MultiSelectPage GetAllSelectedButton()
        {
            _getAllSelectedButton.Click();
            return this;
        }

        public MultiSelectPage ClickOnTwoMultiDropDownElementByValue(string firstValue, string secondValue)
        {
            Actions action = new Actions(Driver);    
            _multiDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control); 
            _multiDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);  
            action.Build().Perform();

            return this;
        }

        public MultiSelectPage ClickOnThreeMultiDropDownElementByValue(string firstValue, string secondValue, string thirdValue)
        {
            Actions action = new Actions(Driver);
            _multiDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            _multiDown.SelectByValue(secondValue);
            _multiDown.SelectByValue(thirdValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();

            return this;
        }

        public MultiSelectPage ClickOnFourMultiDropDownElementByValue(string firstValue, string secondValue, string thirdValue, string fourthValue)
        {
            Actions action = new Actions(Driver);
            _multiDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            _multiDown.SelectByValue(secondValue);
            _multiDown.SelectByValue(thirdValue);
            _multiDown.SelectByValue(fourthValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();

            return this;
        }

        public MultiSelectPage VerifyMiultiSelectValueContains(string expectedValue)
        {
            Assert.IsTrue(_multiDropDownResult.Text.Contains(expectedValue), "Wrong value");

            return this;
        }
    }
}
