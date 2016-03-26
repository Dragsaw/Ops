using Ga.Individuals;
using System.Collections.Generic;
using System.Linq;

namespace Ga.Selection
{
    public class BestNSelectionAlgorithm : ISelectionAlgorithm
    {
        private int take;

        public BestNSelectionAlgorithm(int take)
        {
            this.take = take;
        }

        public IEnumerable<IIndividual> Select(IEnumerable<IIndividual> individuals)
        {
            return individuals.OrderByDescending(x => x.Health).ThenBy(x => x.Generation).Take(take);
        }
    }
}
