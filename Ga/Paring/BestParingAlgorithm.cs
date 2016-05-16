using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;

namespace Ga.Paring
{
    public class BestParingAlgorithm : IParingAlgorithm
    {
        public IPare Pare(IEnumerable<IIndividual> individuals)
        {
            var orderedIndividuals = individuals.OrderByDescending(x => x.Health).ThenBy(x => x.Id);
            return new Pare { First = orderedIndividuals.ElementAt(0), Second = orderedIndividuals.ElementAt(1) };
        }
    }
}
