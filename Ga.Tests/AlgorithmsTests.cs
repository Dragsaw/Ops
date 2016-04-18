using Ga.Chromosomes;
using Ga.Crossover;
using Ga.Individuals;
using Ga.Paring;
using Ga.Selection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Tests
{
    [TestClass]
    public class AlgorithmsTests
    {
        [TestMethod]
        public void Can_Select_Best_Individuals()
        {
            var sa = new BestNSelectionAlgorithm();
            var individuals = new List<Individual>
            {
                new Individual { Health=1 },
                new Individual { Health=2 },
                new Individual { Health=3 }
            };
            var result = sa.Select(individuals, 1);
            Assert.AreEqual(3, result.First().Health, "random selection failed");
        }

        [TestMethod]
        public void Can_Crossover_At_One_Point()
        {
            var ca = new SinglePointCrossoverAlgorithm();
            var pare = new Pare
            {
                First = new Individual { Genome = new List<IChromosome> { new Chromosome { Value = -2, LowerLimit = 0, UpperLimit = 3 } } },
                Second = new Individual { Genome = new List<IChromosome> { new Chromosome { Value = 3, LowerLimit = 0, UpperLimit = 3 } } }
            };
            var result = ca.Crossover(pare, new[] { 2 }, 2);
            Assert.AreEqual("111", result.ElementAt(0).Bits.ToString());
        }
    }
}
