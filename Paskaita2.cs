using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class Paskaita2
    {

        // Tread.Sleep(5000) = laukia, labai retais atvejais naudojamas
        // webDriver.Manage().Timouts().ImplicitWait = TimeSpan.FromSeconds(10); laukia elemento naudojamas daznai

        // webDriver.manage().Windows.Maximize(); padaro ekrana per visa

        //  WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); laukia iki tam tikro dalyko pasirodymo
        // wait.Until(e => e.FindElement(By.Id(""). Dislpayed); pvz popUp ID iesko, kad butu pasirdes
        
        
        public static IWebDriver _driver;


        [OneTimeSetUp]

        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("cookiescript_reject")).Click();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);

            IWebElement popUp = _driver.FindElement(By.CssSelector("#at-cv-lightbox-close"));
            popUp.Click();


        }
    }
}
