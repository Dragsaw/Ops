using Ga.Individuals;
using Ga.Paring;
using Ga.Infrastructure;

namespace Ga.Crossover
{
    public class SinglePointCrossover : ICrossoverAlgorithm
    {
        private int index;

        public SinglePointCrossover(int index)
        {
            this.index = index;
        }

        public IIndividual Crossover(IPare pare)
        {
            var newIndividual = pare.First.Clone();
            var str1 = pare.First.Bits.ToString();
            var str2 = pare.Second.Bits.ToString();
            var crossover = string.Concat(str1.Substring(0, index), str2.Substring(index));
            newIndividual.Update(new Binary(crossover));
            return newIndividual;
        }
    }
}
