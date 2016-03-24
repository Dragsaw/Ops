using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Chromosomes;

namespace Ga.Initialization
{
    public class RandomInitialization : IInitializationAlgorithm
    {
        private int individualsCount;
        private Random random;
        private IChromosome[] chromosomes;

        public RandomInitialization(int individualsCount, params IChromosome[] chromosomes)
        {
            this.random = new Random(DateTime.Now.Millisecond);
            this.individualsCount = individualsCount;
            this.chromosomes = chromosomes;
        }

        public IEnumerable<IIndividual> Initialize()
        {
            var result = new List<IIndividual>();
            for (int i = 0; i < individualsCount; i++)
            {
                var individual = new Individual { Generation = 1 };
                foreach (var c in chromosomes)
                {
                    var newChromosome = c.Clone();
                    newChromosome.Value = random.Next((int)c.LowerLimit, (int)c.UpperLimit) + random.NextDouble();
                    individual.Genome.Add(newChromosome);
                }
                result.Add(individual);
            }

            return result;
        }
    }
}
