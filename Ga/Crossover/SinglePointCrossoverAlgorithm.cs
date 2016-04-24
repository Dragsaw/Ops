using Ga.Individuals;
using Ga.Paring;
using Ga.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Ga.Crossover
{
    public class SinglePointCrossoverAlgorithm : ICrossoverAlgorithm
    {
        public IEnumerable<IIndividual> Crossover(IPare pare, int generation)
        {
            int point = pare.First.BinaryLength / 2;
            var newIndividual1 = pare.First.Clone();
            var newIndividual2 = pare.First.Clone();
            var str1 = pare.First.Bits.ToString();
            var str2 = pare.Second.Bits.ToString();
            var crossover1 = string.Concat(str1.Substring(0, point), str2.Substring(point));
            var crossover2 = string.Concat(str2.Substring(0, point), str1.Substring(point));
            newIndividual1.Update(new Binary(crossover1));
            newIndividual1.Generation = generation;
            newIndividual1.Parents = new Pare { First = pare.First, Second = pare.Second };
            newIndividual2.Update(new Binary(crossover2));
            newIndividual2.Generation = generation;
            newIndividual2.Parents = new Pare { First = pare.Second, Second = pare.First };
            return new IIndividual[] { newIndividual1, newIndividual2 };
        }
    }
}
