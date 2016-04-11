using Ga.Individuals;
using Ga.Paring;
using Ga.Infrastructure;
using System.Collections.Generic;

namespace Ga.Crossover
{
    public class SinglePointCrossoverAlgorithm : ICrossoverAlgorithm
    {
        private int index;

        public SinglePointCrossoverAlgorithm(int index)
        {
            this.index = index;
        }

        public IEnumerable<IIndividual> Crossover(IPare pare, int generation)
        {
            var newIndividual1 = pare.First.Clone();
            var newIndividual2 = pare.First.Clone();
            var str1 = pare.First.Bits.ToString();
            var str2 = pare.Second.Bits.ToString();
            var crossover1 = string.Concat(str1.Substring(0, index), str2.Substring(index));
            var crossover2 = string.Concat(str2.Substring(0, index), str1.Substring(index));
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
