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

        [Test]

        public void ClickOnRinktis()
        {
            _chaiChaiPage.NavigateToDefaultPage().ClickRinktisButton();
        }
    }
}
