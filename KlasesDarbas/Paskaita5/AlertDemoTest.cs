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
    }
}
