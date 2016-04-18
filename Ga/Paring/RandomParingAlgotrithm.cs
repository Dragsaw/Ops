using System;
using System.Collections.Generic;
using Ga.Individuals;
using System.Linq;

namespace Ga.Paring
{
    public class RandomParingAlgorithm : IParingAlgorithm
    {
        private Random random = new Random(DateTime.Now.Millisecond);

        public IPare Pare(IEnumerable<IIndividual> individuals)
        {
            return new Pare
            {
                First = individuals.ElementAt(random.Next(individuals.Count())),
                Second = individuals.ElementAt(random.Next(individuals.Count()))
            };
        }
    }
}
