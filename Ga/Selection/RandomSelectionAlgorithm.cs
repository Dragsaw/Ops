using System;
using System.Collections.Generic;
using System.Linq;
using Ga.Individuals;

namespace Ga.Selection
{
    public class RandomSelectionAlgorithm : ISelectionAlgorithm
    {
        private Random random = new Random(DateTime.Now.Millisecond);

        public IEnumerable<IIndividual> Select(IEnumerable<IIndividual> individuals, int take)
        {
            var result = new IIndividual[2];
            for (int i = 0; i < take; i++)
            {
                result[i] = individuals.ElementAt(random.Next(individuals.Count() - 1));
            }

            return result;
        }
    }
}
