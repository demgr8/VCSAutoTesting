using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.NamuDarbai.NamuDarbas4
{
    class MultiSelectTest : BaseTestNd
    {

        [Test]

        public void MultiDropDownFirstSelectedTestTwoValues()
        {
            _multiSelectPage.NavigateToDefaultPage().ClickOnTwoMultiDropDownElementByValue("Washington", "Texas").
                ClickFirstSelectedButton().VerifyMiultiSelectValueContains("Texas");
        }

        [Test]
        public void MultiDropDownGetAllSelectedTestTwoValues()
        {
            _multiSelectPage.NavigateToDefaultPage().ClickOnTwoMultiDropDownElementByValue("Ohio", "Florida").
                GetAllSelectedButton().VerifyMiultiSelectValueContains("Ohio,Florida");
        }

        [Test]
        public void MultiDropDownFirstSelectedTestThreeValues()
        {
            _multiSelectPage.NavigateToDefaultPage().ClickOnThreeMultiDropDownElementByValue ("New Jersey", "Pennsylvania", "Texas").
                GetAllSelectedButton().VerifyMiultiSelectValueContains("Texas");
        }

        [Test]
        public void MultiDropDownGetAllSelectedTestFourValues()
        {
            _multiSelectPage.NavigateToDefaultPage().ClickOnFourMultiDropDownElementByValue("California", "New Jersey", "Ohio", "Pennsylvania").
                GetAllSelectedButton().VerifyMiultiSelectValueContains("California,New Jersey,Ohio,Pennsylvania");
        }
    }
}
