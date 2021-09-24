using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSTestingRuduo.BaigiamasisDarbas
{
    public class ChaiChaiPage : ChaiChaiBasePage
    {
        private const string _pageAddress = "https://chaichai.lt/";

        private IWebElement _acceptButton => Driver.FindElement(By.Id("cn-accept-cookie"));

        private IWebElement _searchButton => Driver.FindElement(By.CssSelector("body > div.page-wrapper > header.main-header > div > div > ul > li:nth-child(3) > a > svg"));

        private IWebElement _searchField => Driver.FindElement(By.XPath("/html/body/aside[3]/section/div/form/div/input[1]"));

        private IWebElement _chaiTitle => Driver.FindElement(By.CssSelector("#product-546 > div > div.pd-section__col.pd-section__col--img > h1"));

        private IWebElement _menuTabProduktai => Driver.FindElement(By.CssSelector("body > div.page-wrapper > header.main-header > div > nav > ul > li.navigation__item > a"));

        private IWebElement _menuTabPrieskoniai => Driver.FindElement(By.CssSelector("body > div.page-wrapper > aside > nav > ul > li:nth-child(3) > a"));

        private IWebElement _nextPageButton => Driver.FindElement(By.CssSelector("body > div.page-wrapper > div.shop-archive > div > div.inner-wrapper > nav > ul > li:nth-child(6) > a"));

        private IWebElement _purchaseButton => Driver.FindElement(By.CssSelector("body > div.page-wrapper > div.shop-archive > div > div.inner-wrapper > ul > li.card.product-card.wp-sticky.product.type-product.post-181.status-publish.instock.product_cat-prieskoniai.product_cat-prieskoniu-misinys-prieskoniai.has-post-thumbnail.taxable.shipping-taxable.purchasable.product-type-simple > div > a > svg"));

        private IWebElement _product => Driver.FindElement(By.CssSelector(".post-181 .attachment-woocommerce_thumbnail"));

        private IWebElement _productPurchaseButton => Driver.FindElement(By.CssSelector("#product-181 > div > div.pd-section__col.pd-section__col--right > div.chai-meta-wrap > div.chai-meta-wrap__col.chai-meta-wrap__col--first > form > div.chai-carty-mac-cart__second > button"));

        private IWebElement _purchaseBasket => Driver.FindElement(By.CssSelector("body > div.page-wrapper > header.main-header > div > div > ul > li:nth-child(2) > a > svg"));

        private IWebElement _purchaseBasketResult => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/main/article/div/div/form/table/tbody/tr[1]/td[5]/div/div/input"));

        private IWebElement _menuTabArbata => Driver.FindElement(By.CssSelector("body > div.page-wrapper > aside > nav > ul > li:nth-child(2) > a"));

        private IWebElement _zaliojiButton => Driver.FindElement(By.CssSelector("#woocommerce_layered_nav-10 > ul > li:nth-child(11) > a"));
        
        private IReadOnlyCollection<IWebElement> _titlesCollection => Driver.FindElements(By.ClassName("chai-title-p__cat"));

        private IWebElement _menuTabSaldumynai => Driver.FindElement(By.CssSelector("body > div.page-wrapper > aside > nav > ul > li:nth-child(4) > a > span > svg"));

        private IWebElement _product1ToBacket => Driver.FindElement(By.CssSelector("body > div.page-wrapper > div.shop-archive > div > div.inner-wrapper > ul > li.card.product-card.wp-sticky.product.type-product.post-543.status-publish.first.instock.product_cat-saldumynai.has-post-thumbnail.taxable.shipping-taxable.purchasable.product-type-simple > div > a > svg"));
        
        private IWebElement _sum => Driver.FindElement(By.CssSelector("strong bdi"));

        private IWebElement _addButton => Driver.FindElement(By.CssSelector(".woocommerce-cart-form__cart-item:nth-child(1) .js-qa-plus"));

        private IWebElement _removeButton => Driver.FindElement(By.CssSelector(".js-qa-minus"));

        private IWebElement _updateBasketSum => Driver.FindElement(By.Name("update_cart"));
        public ChaiChaiPage(IWebDriver webDriver) : base(webDriver) { }

        public ChaiChaiPage NavigateToDefaultPage()
        {
            if (Driver.Url != _pageAddress)
            {
                Driver.Url = _pageAddress;
            }
            return this;
        }

        public ChaiChaiPage Wait()
        {
            Thread.Sleep(2000);
           // Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return this;
        }

        public ChaiChaiPage ClickOnCookiesAcceptButton()
        {
            _acceptButton.Click();
            return this;
        }

        public ChaiChaiPage ClickOnSearchButton()
        {
            _searchButton.Click();
            return this;
        }

        public ChaiChaiPage InsertTextToSearchField(string text)
        {
            _searchField.Clear();
            _searchField.SendKeys(text);
            return this;
        }



        public ChaiChaiPage ClickEnterAfterValueInputInSerachBox()
        {

            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Enter);
            action.Build().Perform();
            return this;
        }
         
        public ChaiChaiPage VerifySearchResults(string acctualResult) 
        {

            Assert.That(_chaiTitle.Text, Is.EqualTo(acctualResult),
            "Result is different");

            return this;
        }

        public ChaiChaiPage ClickOnMenuTabProduktai()
        {
            _menuTabProduktai.Click();
            return this;
        }

        public ChaiChaiPage ClickOnMenuTabPrieskoniai()
        {
            _menuTabPrieskoniai.Click();
            return this;
        }

        public ChaiChaiPage ScrollDownToElementNextButton()
        {

            Actions action = new Actions(Driver);
            action.MoveToElement(_nextPageButton);
            action.Build().Perform();
            return this;
        }

        public ChaiChaiPage ScrollDownToProductPurchaseElement()
        {

            Actions action = new Actions(Driver);
            action.MoveToElement(_purchaseButton);
            action.Build().Perform();
            return this;
        }

        public ChaiChaiPage ScrollDown()
        {

            Actions action = new Actions(Driver);
            action.SendKeys(Keys.PageDown);
            action.Build().Perform();
            return this;
        }


        public ChaiChaiPage ClickOnNextPageButton()
        {
            _nextPageButton.Click();
            return this;
        }

        public ChaiChaiPage ClickOnPurchaseButton()
        {
            _purchaseButton.Click();
            return this;
        }

        public ChaiChaiPage ClickOnProduct()
        {
            _product.Click();
            return this;
        }

        public ChaiChaiPage ClickOnProductPurchaseButton()
        {
            _productPurchaseButton.Click();
            return this;
        }

    
        public ChaiChaiPage ClickOnPurchaseBasketButton()
        {
            _purchaseBasket.Click();
            return this;
        }
    
        public ChaiChaiPage VerifyIfPurchaseBasetResultIsCorrect(string acctualquantity)
        {

            Assert.That(_purchaseBasketResult.GetAttribute("value"), Is.EqualTo(acctualquantity),
                    "Result is different");
            return this;
        }

        public ChaiChaiPage ClickOnMenuTabArbata()
        {
            _menuTabArbata.Click();
            return this;
        }

        public ChaiChaiPage ScrollDownToElementZalioji()
        {

            Actions action = new Actions(Driver);
            action.MoveToElement(_zaliojiButton);
            action.Build().Perform();
            return this;
        }

        public ChaiChaiPage ClickOnFilterZalioji()
        {
            _zaliojiButton.Click();
            return this;
        }

        public ChaiChaiPage VerifyFilterResults(string nameResult)
        {
            foreach (IWebElement name in _titlesCollection)
            {
                Assert.That(name.Text, Is.EqualTo(nameResult),
                    $"Result is different. Should be {name.Text}, but was {nameResult}");
            }

            return this;
        }

        public ChaiChaiPage ClickOnMenuTabSaldumynai()
        {
            _menuTabSaldumynai.Click();
            return this;
        }

        public ChaiChaiPage ClickOnProduct1ToPutInBacket()
        {
            _product1ToBacket.Click();
            return this;
        }

        public ChaiChaiPage VerifyIfPurchaseBasketSumIsCorrect(string acctualSum)
        {
            Assert.That(_sum.Text, Is.EqualTo(acctualSum), "Result is different");
            return this;
        }

        public ChaiChaiPage ClickOnAddButtonInBasket()
        {
            _addButton.Click();
            return this;
        }
        public ChaiChaiPage ClickOnRemoveButtonInBasket()
        {
            _removeButton.Click();
            return this;
        }

        public ChaiChaiPage ClickOnUpdateButtonInBasket()
        {
            _updateBasketSum.Click();
            return this;
        }

    }


}

