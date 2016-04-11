using Ga.Chromosomes;
using Ga.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Tests
{
    [TestClass]
    public class ChromosomeTests
    {
        [TestMethod]
        public void Chromosome_Is_Invalid_If_Out_Of_Bounds()
        {
            var c = new Chromosome { LowerLimit = 0, UpperLimit = 2, Value = 3 };
            Assert.IsFalse(c.IsValid);
        }

        [TestMethod]
        public void Can_Represent_Chromosome_As_Binary()
        {
            var c = new Chromosome { LowerLimit = 0, UpperLimit = 4, Value = 3 };
            var b = c.Bits;
            Assert.AreEqual("0011", b.ToString(), "bin representations differ");
            Assert.AreEqual(c.Value, b.NumericValue, "numeric values differ");
            Assert.AreEqual(c.BinaryLength, b.Value.Count(), "lengths are not equal");
        }

        [TestMethod]
        public void Can_Restore_Chromosome_Value()
        {
            var c = new Chromosome { LowerLimit = 0, UpperLimit = 4, Value = 3, Scale = 1 };
            c.Update(new Binary("00100000", 1));
            var b = c.Bits;
            Assert.AreEqual("00100000", b.ToString(), "bin representations differ");
            Assert.AreEqual(2, c.Value, "chromosome value is different");
            Assert.AreEqual(c.Value, b.NumericValue, "numeric values differ");
            Assert.AreEqual(c.BinaryLength, b.Value.Count(), "lengths are not equal");
        }
    }
}
