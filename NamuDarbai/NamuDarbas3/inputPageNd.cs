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

namespace VCSTestingRuduo.NamuDarbai.NamuDarbas3
{
    class InputPageNd
    {
        public static IWebDriver _driver;

        private IWebElement _singleCheckBoxClick => _driver.FindElement(By.Id("isAgeSelected"));

        private IWebElement _actutalResultSingleCheckBox => _driver.FindElement(By.Id("txtAge"));

        private IReadOnlyCollection<IWebElement> _multipleCheckBoxes => _driver.FindElements(By.ClassName("cb1-element"));

        private IWebElement _multipleCheckBoxesButton => _driver.FindElement(By.CssSelector("#check1"));


        public InputPageNd(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void ClickSingleChexkBoxButton()
        {
            _singleCheckBoxClick.Click();
        }

        public void VerifySingleCheckBoxResult()
        {
            Assert.IsTrue(_actutalResultSingleCheckBox.Text.Contains("Success - Check box is checked"));
        }

        public void SelectAllCheckBoxes()
        {
            foreach (IWebElement checkBox in _multipleCheckBoxes)
            {
                if (!checkBox.Selected)
                {
                    checkBox.Click();
                }
            }
        }

        public void VerifyResultUncheckAll(string text)
        {
            Assert.IsTrue(_multipleCheckBoxesButton.GetAttribute("value").Equals(text));
        }

        public void ClickMultipleChexkBoxButton(string text)
        {

            if (_multipleCheckBoxesButton.GetAttribute("value").Equals(text))
            {
                _multipleCheckBoxesButton.Click();
            }
        }

        public void VerifyResultIfAllChechBoxesAreUnChecked()
        {
            foreach (IWebElement checkBox in _multipleCheckBoxes)
            {
                if (checkBox.Selected)
                {
                    checkBox.Click();
                }
            }
        }

    }
}
