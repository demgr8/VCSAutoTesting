using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSTestingRuduo.KlasesDarbas.Paskaita4;

namespace VCSTestingRuduo.KlasesDarbas.Paskaita5
{
    public class AlertDemoPage : BasePage
    {
        private const string _youPressedCancelString = "You pressed Cancel!";

        private const string _pageAdress = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";

        private const string _thirdAlertText = "You have entered";

        private IWebElement _firstAlertButton => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > button"));

        private IWebElement _secondAlertButton => Driver.FindElement(By.XPath("//*[@id='easycont']/div/div[2]/div[2]/div[2]/button"));

        private IWebElement _thirdAlertButton => Driver.FindElement(By.XPath("//*[@id='easycont']/div/div[2]/div[3]/div[2]/button"));

        private IWebElement _secondAlertMessageText => Driver.FindElement(By.Id("confirm-demo"));

        private IWebElement _thirdAlertMessageTest => Driver.FindElement(By.Id("prompt-demo"));

        public AlertDemoPage(IWebDriver webDriver) : base(webDriver) { }

        public AlertDemoPage NavigateToDefaultPage() 
        {
         if (Driver.Url != _pageAdress)
            {
                Driver.Url = _pageAdress;
            }
            return this;
        
        }

        public AlertDemoPage ClickFirstAlertButton()
        {
            _firstAlertButton.Click();
            return this;
        }

        public AlertDemoPage AcceptFirsAlert()
        {
            Driver.SwitchTo().Alert().Accept();
            return this;
        }

        public AlertDemoPage ClickSecondAlertButton()
        {
            _secondAlertButton.Click();
            return this;
        }

        public AlertDemoPage ClickThirAlertButton()
        {
            _thirdAlertMessageTest.Click();
            return this;
        }

        public AlertDemoPage DismissSecondAlert()
        {
            Driver.SwitchTo().Alert().Dismiss();
                return this;
        }

        public AlertDemoPage VerifySecondAlertText()
        {
            Assert.AreEqual(_youPressedCancelString, _secondAlertMessageText.Text, "Text is wrong!");
            return this;
        }

        public AlertDemoPage SendKeysToThirdAlertButton(string text)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();

            return this;
        }

        //sita paziuret!
       // public AlertDemoPage VerifyThirAlertText(string resutText)
       // {
          //  Assert.IsTrue(_thirdAlertText + " '" + resutText + "' !").Equals(_thirdAlertMessageTest.Text, "Text is wrong!"));
          //  return this;
        //}


    }
}
