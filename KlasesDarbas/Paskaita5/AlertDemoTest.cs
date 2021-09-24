using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSTestingRuduo.KlasesDarbas.Paskaita5
{
    class AlertDemoTest : BaseTest
    {

        [Test]

        public static void TestFirsAlert()
        {
            _alertDemoPage.NavigateToDefaultPage().ClickFirstAlertButton().AcceptFirsAlert();

        }
    
        [Test]
        public static void TestSecondAlert()
        {
            _alertDemoPage.NavigateToDefaultPage().ClickSecondAlertButton().
                DismissSecondAlert().VerifySecondAlertText();
        }
    
    
        [Test]
        public static void TestThirdAlert()
        {
            _alertDemoPage.NavigateToDefaultPage().ClickThirAlertButton().
                SendKeysToThirdAlertButton("Penktadienis");// VerifyThirAlertText("Penktadienis");
                
        }
    }
}
