using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayService;

namespace PayServiceTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void PayOnlineNormalDataTest()
        {
            PayService.PayService ps = new PayService.PayService();
            bool actual = ps.PayOnline("1234123412340001", 2018, 5, "IVAN PETROV", "123", 0);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void PayOnlineInvalidCardNumberTest()
        {
            PayService.PayService ps = new PayService.PayService();
            bool actual = ps.PayOnline("00000000", 2018, 5, "IVAN PETROV", "123", 0);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void PayOnlineInvalidExpDateTest()
        {
            PayService.PayService ps = new PayService.PayService();
            bool actual = ps.PayOnline("1234123412340001", 2007, 9, "IVAN PETROV", "123", 0);
            Assert.IsFalse(actual);
        }
    }
}
