using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Infrastructure;
using Ga.Paring;

namespace Ga.Mutation
{
    public class ClassicMutation : IMutationAlgorithm
    {
        private Random random = new Random(DateTime.Now.Millisecond);

        public IIndividual Mutate(IIndividual individual, double mutationChance)
        {
            bool mutationHappened = false;
            var binary = individual.Bits;
            for (int i = 0; i < individual.BinaryLength; i++)
            {
                var mutate = random.NextDouble() < mutationChance;
                if (mutate)
                {
                    binary.Revert(i);
                    mutationHappened = true;
                }
            }

            if (mutationHappened == false)
            {
                return null;
            }

            var newIndividual = individual.Clone();
            newIndividual.Update(binary);
            newIndividual.Id = individual.Id;
            newIndividual.IsMutant = true;
            newIndividual.Parents = new Pare { First = individual, Second = null };
            return newIndividual;
        }
    }
}
