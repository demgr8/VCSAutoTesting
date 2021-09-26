using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.BaigiamasisDarbas
{
    public class ChaiChaiTest : ChaiChaiBaseTest
    {

        [TestCase("Migdolai baltame šokolade su kokosu")]

        public void SearchSystemTesting(string input)
        {
            _chaiChaiPage.NavigateToDefaultPage()
                .AcceptCookies()
                .ClickOnSearchButton()
                .InsertTextToSearchField(input)
                .ClickEnterAfterValueInputInSerachBox()
                .VerifySearchResults(input);
        }
    
         [TestCase("2")]

        public void TestingIfItemsQuantityIsCorrectByClickingPurchaseButtonsInDifferentPlace(string input)
        {
            _chaiChaiPage.NavigateToDefaultPage()
                .AcceptCookies()
                .ClickOnMenuTabProduktai()
                .ClickOnMenuTabPrieskoniai()
                .ScrollDownToElementNextButton()
                .ClickOnNextPageButton()
                .ScrollDownToProductPurchaseElement()
                .ClickOnPurchaseButton()
                .ClickOnProduct()
                .ScrollDown()
                .ClickOnProductPurchaseButton()
                .ClickOnPurchaseBasketButton()
                .VerifyIfPurchaseBasetResultIsCorrect(input);
               
        }

        [TestCase("Žalioji arbata")]
        public void FilterTesting(string input)
        {
            _chaiChaiPage.NavigateToDefaultPage()
                .AcceptCookies()
                .ClickOnMenuTabProduktai()
                .ClickOnMenuTabArbata()
                .ScrollDownToElementZalioji()
                .ClickOnFilterZalioji()
                .ScrollDown()
                .VerifyFilterResults(input);
        }

        [TestCase("€4.00", "€12.00", "€8.00")]

        public void BasketUpdateTesting(string input1, string input2, string input3)
        {
            _chaiChaiPage.NavigateToDefaultPage()
                .AcceptCookies()
                .ClickOnMenuTabProduktai()
                .ClickOnMenuTabSaldumynai()
                .ScrollDown()
                .ClickOnProduct1ToPutInBacket()
                .WaitForBasketIconUpdate()
                .ClickOnPurchaseBasketButton()
                .VerifyIfPurchaseBasketSumIsCorrect(input1)
                .ClickOnAddButtonInBasket()
                .ClickOnAddButtonInBasket()
                .ClickOnUpdateButtonInBasket()
                .WaitForBasketUpdateCondition1()
                .VerifyIfPurchaseBasketSumIsCorrect(input2)
                .ClickOnRemoveButtonInBasket()
                .ClickOnUpdateButtonInBasket()
                .WaitForBasketUpdateCondition2()
                .VerifyIfPurchaseBasketSumIsCorrect(input3);
        }

        [TestCase("€4.00", "€8.00", "€7.00")]

        public void AccurateCalculationOfShippingCostsWithDifferentOptions(string input1, string input2, string input3)
        {
            _chaiChaiPage.NavigateToDefaultPage()
                .AcceptCookies()
                .ClickOnMenuTabProduktai()
                .ClickOnMenuTabSaldumynai()
                .ScrollDown()
                .ClickOnProduct1ToPutInBacket()
                .WaitForBasketIconUpdate()
                .ClickOnPurchaseBasketButton()
                .ClickOnCheckOutButton()
                .ScrollDown()
                .ClickOnRadioButton2()
                .WaitForBasketLocalPickUpUpdate()
                .VerifyIfCostWithShippingSumIsAccurate(input1)
                .ClickOnRadioButton1()
                .WaitForAddressTextApears()
                .VerifyIfCostWithShippingSumIsAccurate(input2)
                .ClickOnRadioButton3()
                .WaitForDpdTerminalApears()
                .VerifyIfCostWithShippingSumIsAccurate(input3);
        }

        [TestCase("Harissa")]
        public void TestingIfAllImportantInfoIsDisplayed(string input)
        {
            _chaiChaiPage.NavigateToDefaultPage()
               .AcceptCookies()
               .ClickOnMenuTabProduktai()
               .ClickOnMenuTabPrieskoniai()
               .ScrollDownToElementNextButton()
               .ClickOnNextPageButton()
               .ScrollDownToProductPurchaseElement()
               .ClickOnProduct()
               .VerifyIfImageIsDisplayed()
               .VerifyIfProductTitleIsCorrect("Harissa")
               .VerifyIfProductPriceIsDisplayed()
               .VerifyIfProductScockIsDisplayed()
               .VerifyIfProductPurchaseButtonIsDisplayed();
        }
    }
}
