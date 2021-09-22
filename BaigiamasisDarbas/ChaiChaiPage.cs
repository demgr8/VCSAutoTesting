using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.BaigiamasisDarbas
{
    public class ChaiChaiPage : ChaiChaiBasePage
    {
        private const string _pageAddress = "https://chaichai.lt/";

        private IWebElement _buttonRinktis => Driver.FindElement(By.CssSelector("body > div.page-wrapper > section.slider > ul > div > div > li > div > div > div > a"));

       // private IWebElement _varify => Driver.FindElement(By.CssSelector("body > div.page-wrapper > div.shop-archive > div > div.inner-wrapper > ul > li.card.product-card.wp-sticky.product.type-product.post-536.status-publish.first.instock.product_cat-prieskoniai.product_cat-prieskoniu-misinys-prieskoniai.has-post-thumbnail.taxable.shipping-taxable.purchasable.product-type-simple > a > div > h2"));




        public ChaiChaiPage(IWebDriver webDriver) : base(webDriver) { }

        public ChaiChaiPage NavigateToDefaultPage()
        {
            if (Driver.Url != _pageAddress)
            {
                Driver.Url = _pageAddress;
            }
            return this;
        }

        public ChaiChaiPage ClickRinktisButton()
        {
            _buttonRinktis.Click();
            return this;
        }

       // public ChaiChaiPage Varify(string p)
        //{
        //    Assert.IsTrue(_varify.Text.Contains(p), "No");
         //   return this;
       // }
    }
}
