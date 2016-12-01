using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void testAdd()
        {
            var a = new Calculator();
            a.add(-14);
            Assert.AreEqual(-14, a.total);
        }
        [TestMethod]
        public void testSubstract()
        {
            var a = new Calculator();
            a.substract(-14);
            Assert.AreEqual(-14, a.total);

        }
        [TestMethod]
        public void testProduct()
        {
            var a = new Calculator();
            a.product(-14);
            Assert.AreEqual(0, a.total);

        }
        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void testDivide()
        {
            var a = new Calculator();
            a.divide(0);
            Assert.AreEqual(0, a.total);
        }
    }
}
