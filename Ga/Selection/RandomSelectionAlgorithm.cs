using System;
using System.Collections.Generic;
using System.Linq;
using Ga.Individuals;

namespace Ga.Selection
{
    public class RandomSelectionAlgorithm : ISelectionAlgorithm
    {
        private int count;
        private Random random;

        public RandomSelectionAlgorithm(int numberOfIndividuals)
        {
            this.count = numberOfIndividuals;
            this.random = new Random(DateTime.Now.Millisecond);
        }

        public IEnumerable<IIndividual> Select(IEnumerable<IIndividual> individuals)
        {
            var result = new IIndividual[2];
            for (int i = 0; i < count; i++)
            {
                result[i] = individuals.ElementAt(random.Next(individuals.Count() - 1));
            }

            return result;
        }
    }
}
