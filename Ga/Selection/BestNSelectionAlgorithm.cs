using Ga.Individuals;
using System.Collections.Generic;
using System.Linq;

namespace Ga.Selection
{
    public class BestNSelectionAlgorithm : ISelectionAlgorithm
    {
        public IEnumerable<IIndividual> Select(IEnumerable<IIndividual> individuals, int take)
        {
            return individuals.OrderByDescending(x => x.Health).ThenBy(x => x.Generation).Take(take);
        }
    }
}
