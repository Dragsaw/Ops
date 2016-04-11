using System;
using System.Collections.Generic;
using Ga.Individuals;
using System.Linq;

namespace Ga.Paring
{
    public class RandomParingAlgotrithm : IParingAlgorithm
    {
        int paresCount;
        Random random;

        public RandomParingAlgotrithm(int paresCount)
        {
            this.paresCount = paresCount;
            random = new Random(DateTime.Now.Millisecond);
        }

        public IEnumerable<IPare> Pare(IEnumerable<IIndividual> individuals)
        {
            var result = new List<IPare>();

            for (int i = 0; i < paresCount; i++)
            {
                var first = random.Next(individuals.Count());
                var second = random.Next(individuals.Count());
                result.Add(new Pare { First = individuals.ElementAt(first), Second = individuals.ElementAt(second) });
            }

            return result;
        }
    }
}
