using Ga.Individuals;
using System.Collections.Generic;
using System.Linq;

namespace Ga.Selection
{
    public class RandomSelectionAlgorithm : ISelectionAlgorithm
    {
        private int take;

        public RandomSelectionAlgorithm(int take)
        {
            this.take = take;
        }

        public IEnumerable<IIndividual> Select(IEnumerable<IIndividual> individuals)
        {
            return individuals.OrderByDescending(x => x.Health).ThenBy(x => x.Generation).Take(take);
        }
    }
}
