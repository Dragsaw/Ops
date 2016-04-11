using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Chromosomes;

namespace Ga.Initialization
{
    public class RandomInitializationAlgorithm : IInitializationAlgorithm
    {
        private int individualsCount;
        private Random random;
        private IChromosome[] chromosomes;

        public RandomInitializationAlgorithm(int individualsCount, params IChromosome[] chromosomes)
        {
            this.random = new Random(DateTime.Now.Millisecond);
            this.individualsCount = individualsCount;
            this.chromosomes = chromosomes;
        }

        public IEnumerable<IIndividual> Initialize()
        {
            var result = new IIndividual[individualsCount];
            Parallel.For(0, individualsCount, i => result[i] = GenerateIndividual());
            return result;
        }

        private IIndividual GenerateIndividual()
        {
            var individual = new Individual { Generation = 1 };
            foreach (var c in chromosomes)
            {
                var newChromosome = c.Clone();
                newChromosome.Value = random.Next((int)c.LowerLimit, (int)c.UpperLimit) + random.NextDouble();
                individual.Genome.Add(newChromosome);
            }
            return individual;
        }
    }
}
