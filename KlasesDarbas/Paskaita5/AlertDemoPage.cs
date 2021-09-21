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
        private const string _pageAdress = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";

        private IWebElement _firstAlertButton => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > button"));



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

    }
}
