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
        private Random random = new Random(DateTime.Now.Millisecond);

        public IEnumerable<IIndividual> Initialize(int individualsCount, params IChromosome[] chromosomes)
        {
            var result = new IIndividual[individualsCount];
            Parallel.For(0, individualsCount, i => result[i] = GenerateIndividual(chromosomes));
            return result;
        }

        private IIndividual GenerateIndividual(IEnumerable<IChromosome> chromosomes)
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
