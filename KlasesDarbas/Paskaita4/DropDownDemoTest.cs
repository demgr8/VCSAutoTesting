using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSTestingRuduo.KlasesDarbas.Paskaita5;

namespace VCSTestingRuduo.KlasesDarbas.Paskaita4
{
    class DropDownDemoTest : BaseTest
    {

    
        [Test]

        public void TestDropDown()
        {
            _dropDownDemoPage.NavigateToDefaultPage().SelectFromDropDownByValue("Monday").
                VerifyResult("Monday");
        }

        [Test]
        public void TestDropDownMultiple()
        {
            _dropDownDemoPage.NavigateToDefaultPage().
                ClickOnMultiDropDownElementByValue("Florida", "New York").
                GetAllSelectedButton().VerifyMiultiSelectValueContains("New York");
        }
    }
}
