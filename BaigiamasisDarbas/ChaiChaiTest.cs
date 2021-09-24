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
            _chaiChaiPage.NavigateToDefaultPage().ClickOnCookiesAcceptButton().
                ClickOnSearchButton().InsertTextToSearchField(input).
                ClickEnterAfterValueInputInSerachBox().VerifySearchResults(input);
        }
    
         [TestCase("2")]

        public void TestingIfItemsQuantityIsCorrectByClickingPurchaseButtonsInDifferentPlace(string input)
        {
            _chaiChaiPage.NavigateToDefaultPage().ClickOnCookiesAcceptButton().
                ClickOnMenuTabProduktai().ClickOnMenuTabPrieskoniai().
                ScrollDownToElementNextButton().ClickOnNextPageButton().ScrollDownToProductPurchaseElement().
                ClickOnPurchaseButton().Wait().ClickOnProduct().ScrollDown().
                ClickOnProductPurchaseButton().ClickOnPurchaseBasketButton().
                VerifyIfPurchaseBasetResultIsCorrect(input);
        }

        [TestCase("Žalioji arbata")]
        public void FilterTesting(string input)
        {
            _chaiChaiPage.NavigateToDefaultPage().ClickOnCookiesAcceptButton().
                ClickOnMenuTabProduktai().ClickOnMenuTabArbata().ScrollDownToElementZalioji().
                ClickOnFilterZalioji().ScrollDown().VerifyFilterResults(input);
        }

        [TestCase("€4.00", "€12.00", "€8.00")]

        public void BasketUpdateTesting(string input1, string input2, string input3)
        {
            _chaiChaiPage.NavigateToDefaultPage().ClickOnCookiesAcceptButton().ClickOnMenuTabProduktai().
                ClickOnMenuTabSaldumynai().ScrollDown().ClickOnProduct1ToPutInBacket().Wait().
               ClickOnPurchaseBasketButton().VerifyIfPurchaseBasketSumIsCorrect(input1).
               ClickOnAddButtonInBasket().ClickOnAddButtonInBasket().ClickOnUpdateButtonInBasket().Wait().
               VerifyIfPurchaseBasketSumIsCorrect(input2).ClickOnRemoveButtonInBasket().
               ClickOnUpdateButtonInBasket().Wait().VerifyIfPurchaseBasketSumIsCorrect(input3);
        }


    }
}
