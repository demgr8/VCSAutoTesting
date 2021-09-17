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
    public class SimpleFormDemoTest
    {
        [Test]
        public static void TestSingleInputField()
        {
            //pakelia browser
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();

            //susiranda web elementa
            IWebElement inputField = driver.FindElement(By.Id("user-message"));

            //testas kuris bus irasomas i inputField
            string myText = "Hello";

            //iraso texta i input field
            inputField.SendKeys(myText);

            //popUt idendifikacija
            IWebElement popUp = driver.FindElement(By.CssSelector("#at-cv-lightbox-close"));
            popUp.Click();

            //copy -> copy selector = get input > button
            IWebElement showMessageButton = driver.FindElement(By.CssSelector("#get-input > button"));

            //paspaudzia
            showMessageButton.Click();

            //identifikiuojan acualt result elementus
            IWebElement actualResultText = driver.FindElement(By.Id("display"));

            //tikrinam Expected vs Actual
            // Assert.AreEqual(myText, actualResultText.Text, "Text is different");   vienodi
            Assert.IsTrue(actualResultText.Text.Contains(myText), "Text is different");

             driver.Quit(); //uzdaro narsykle
            

        }

    }
}
