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
using VCSTestingRuduo.KlasesDarbas.Paskaita6;

namespace VCSTestingRuduo.KlasesDarbas.Paskaita5
{
    public class BaseTest
    {
        protected static IWebDriver Driver;
        public static BasicCheckboxDemoPage _basicCheckboxDemoPage; // cia yra objektai
        public static DropDownDemoPage _dropDownDemoPage;
        public static InputPage _inputPage;
        public static AlertDemoPage _alertDemoPage;
        public static SenukaiPage _senukaiPage;

        [OneTimeSetUp]

        public static void SetUp()
        {
            Driver = CustomDriver.GetIncogdinotChromeDriver(); //GetChromeDriver
            _basicCheckboxDemoPage = new BasicCheckboxDemoPage(Driver);
            _dropDownDemoPage = new DropDownDemoPage(Driver);
            _inputPage = new InputPage(Driver);
            _alertDemoPage = new AlertDemoPage(Driver);
            _senukaiPage = new SenukaiPage(Driver);
        }

       // [OneTimeTearDown]
       // public static void TearDown()
        //{
       //     Driver.Close();
       // }


    }
}
