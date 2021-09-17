using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class Paskaita1  //testas naudijamos public klases
    {
        //patikrinti 4 yra lyginis skaicius

        [Test]
        public static void TestIf4IsEven()
        {
            int leftOver = 4 % 2;
            Assert.AreEqual(0, leftOver, "4 is not even"); //1 expected result, 2 skaiciavimai(vyksta tikrinimas), 3 pranesimas jeigu sufeilino
        }

        //patikrina ar dabar 20h
        [Test]
        public static void TestIfNowIs20()
        {
            DateTime currentTime = DateTime.Now; //priskiriam dabartinis laikas
            Assert.AreEqual(20, currentTime.Hour, "Now is not 20h");
        }

        [Test]
        public static void TestCromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://login.yahoo.com/";
            driver.Manage().Window.Maximize();
            driver.Quit(); //uzdaro narsykle
        }

        [Test]
        public static void TestFireFoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();  //isijungia su firefox
            driver.Url = "https://login.yahoo.com/";
            driver.Manage().Window.Maximize();
            driver.Quit();
        }


        


    }
}
