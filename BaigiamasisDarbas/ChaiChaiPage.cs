using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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

        private IWebElement _product1ToBacket => Driver.FindElement(By.CssSelector(".post-543 .chai-add-to-cart__btn"));

        private IWebElement _sum => Driver.FindElement(By.CssSelector("strong bdi"));

        private IWebElement _addButton => Driver.FindElement(By.CssSelector(".woocommerce-cart-form__cart-item:nth-child(1) .js-qa-plus"));

        private IWebElement _removeButton => Driver.FindElement(By.CssSelector(".js-qa-minus"));

        private IWebElement _updateBasketSum => Driver.FindElement(By.Name("update_cart"));

        private IWebElement _checkOutButton => Driver.FindElement(By.CssSelector("body > div.page-wrapper > div:nth-child(5) > main > article > div > div > div.cart-collaterals > div > div.wc-proceed-to-checkout > div > a.checkout-button.button.alt.wc-forward"));

        private IWebElement _radioButton1 => Driver.FindElement(By.Id("shipping_method_0_dpd_home_delivery9"));

        private IWebElement _radioButton2 => Driver.FindElement(By.Id("shipping_method_0_local_pickup4"));

        private IWebElement _radioButton3 => Driver.FindElement(By.Id("shipping_method_0_dpd_parcels3"));

        private IWebElement _totalSumWithShipping => Driver.FindElement(By.CssSelector("#order_review > table > tfoot > tr.order-total > td > strong > span > bdi"));

        private IWebElement _productImage => Driver.FindElement(By.CssSelector(".post-181 .attachment-woocommerce_thumbnail"));

        private IWebElement _productTitle => Driver.FindElement(By.CssSelector("#product-181 > div > div.pd-section__col.pd-section__col--img > h1"));

        private IWebElement _productPriceField => Driver.FindElement(By.CssSelector("#product-181 > div > div.pd-section__col.pd-section__col--right > div.chai-meta-wrap > div.chai-meta-wrap__col.chai-meta-wrap__col--first > form > div.chai-carty-mac-cart__second > p > span > span.chai-price__price > span > bdi"));

        private IWebElement _productStockField => Driver.FindElement(By.CssSelector(".stock"));


        public ChaiChaiPage(IWebDriver webDriver) : base(webDriver) { }


        public ChaiChaiPage NavigateToDefaultPage()
        {
            if (Driver.Url != _pageAddress)
            {
                Driver.Url = _pageAddress;
            }
            return this;
        }

        public ChaiChaiPage WaitForBasketIconUpdate()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("count-cart-items")).Displayed);

            return this;
        }

        public ChaiChaiPage WaitForBasketUpdateCondition1()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("body > div.page-wrapper > div:nth-child(5) > main > article > div > div > div.woocommerce-notices-wrapper > div.woocommerce-message")).Displayed);

            return this;
        }

        public ChaiChaiPage WaitForBasketUpdateCondition2()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector(".product-subtotal bdi")).Text.Equals("€8.00"));
            return this;
        }

        public ChaiChaiPage WaitForAddressTextApears()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("#billing_address_1_field > label")).Displayed);

            return this;
        }

        public ChaiChaiPage WaitForDpdTerminalApears()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("wc_shipping_dpd_parcels_terminal")).Displayed);

            return this;
        }

        public ChaiChaiPage WaitForBasketLocalPickUpUpdate()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("#order_review > table > tfoot > tr.order-total > td > strong > span > bdi")).Text.Equals("€4.00"));
            return this;
        }

        public ChaiChaiPage AcceptCookies()
        {
            Cookie newCookie = new Cookie("cookie_notice_accepted", "true",
                "chaichai.lt", "/", DateTime.Now.AddDays(3));
            Driver.Manage().Cookies.AddCookie(newCookie);
            Driver.Navigate().Refresh();
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
                Assert.That(name.Text, Is.EqualTo(nameResult), "Result is not correct");
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

        public ChaiChaiPage ClickOnCheckOutButton()
        {
            _checkOutButton.Click();
            return this;
        }

        public ChaiChaiPage ClickOnRadioButton1()
        {
            _radioButton1.Click();
            return this;
        }

        public ChaiChaiPage ClickOnRadioButton2()
        {
            _radioButton2.Click();
            return this;
        }

        public ChaiChaiPage ClickOnRadioButton3()
        {
            _radioButton3.Click();
            return this;
        }

        public ChaiChaiPage VerifyIfCostWithShippingSumIsAccurate(string acctualSum)
        {
            Assert.That(_totalSumWithShipping.Text, Is.EqualTo(acctualSum), "Result is wrong");
            return this;
        }

        public ChaiChaiPage VerifyIfImageIsDisplayed()
        {
            bool imagePresent = _productImage.Displayed;
            Assert.True(imagePresent, "No image exist");
            return this;
        }

        public ChaiChaiPage VerifyIfProductTitleIsCorrect(string acctualResult)
        {
            Assert.That(_productTitle.Text, Is.EqualTo(acctualResult),
            "Result is different");

            return this;
        }

        public ChaiChaiPage VerifyIfProductPriceIsDisplayed()
        {
            bool pricePresent = _productPriceField.Displayed;
            Assert.True(pricePresent, "No price field exist");
            return this;
        }

        public ChaiChaiPage VerifyIfProductScockIsDisplayed()
        {
            bool stockPresent = _productStockField.Displayed;
            Assert.True(stockPresent, "No stock field exist");
            return this;
        }

        public ChaiChaiPage VerifyIfProductPurchaseButtonIsDisplayed()
        {
            bool purchaseButtonPresent = _productPurchaseButton.Displayed;
            Assert.True(purchaseButtonPresent, "No purchase button exist");
            return this;
        }
    }
}