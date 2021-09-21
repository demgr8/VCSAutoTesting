using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSTestingRuduo.KlasesDarbas.Page;
using VCSTestingRuduo.KlasesDarbas.PageObjectPattern;
using VCSTestingRuduo.KlasesDarbas.Paskaita4;
using VCSTestingRuduo.KlasesDarbas.Paskaita5.Drivers;

namespace VCSTestingRuduo.KlasesDarbas.Paskaita5
{
    public class BaseTest
    {
        protected static IWebDriver Driver;
        public static BasicCheckboxDemoPage _basicCheckboxDemoPage; // cia yra objektai
        public static DropDownDemoPage _dropDownDemoPage;
        public static InputPage _inputPage;
        public static AlertDemoPage _alertDemoPage;

        [OneTimeSetUp]

        public static void SetUp()
        {
            Driver = CustomDriver.GetChromeDriver();
            _basicCheckboxDemoPage = new BasicCheckboxDemoPage(Driver);
            _dropDownDemoPage = new DropDownDemoPage(Driver);
            _inputPage = new InputPage(Driver);
            _alertDemoPage = new AlertDemoPage(Driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            Driver.Close();
        }


    }
}
