using Ga.Chromosomes;
using Ga.Individuals;
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
    public class IndividualTests
    {
        [TestMethod]
        public void Can_Represent_Individual_As_Binary()
        {
            var i = new Individual();
            var c = new Chromosome() { LowerLimit = 0, UpperLimit = 4, Value = 2 };
            i.Genome.Add(c);
            i.Genome.Add(c);
            var b = i.Bits;
            var strResult = b.ToString();
            Assert.AreEqual("00100010", strResult, "individual to binary failed");
            Assert.AreEqual(c.BinaryLength * 2, i.BinaryLength, "lengths differ");
        }

        [TestMethod]
        public void Can_Restore_Individual()
        {
            var i = new Individual();
            var c1 = new Chromosome() { LowerLimit = 0, UpperLimit = 4, Value = 2 };
            var c2 = new Chromosome() { LowerLimit = 0, UpperLimit = 4, Value = 2 };
            i.Genome.Add(c1);
            i.Genome.Add(c2);
            i.Update(new Binary("01001100"));
            Assert.AreEqual(4, i.Genome[0].Value, "first chromosome values differ");
            Assert.AreEqual(-4, i.Genome[1].Value, "first chromosome values differ");
        }
    }
}
