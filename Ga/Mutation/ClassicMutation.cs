using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Infrastructure;

namespace Ga.Mutation
{
    public class ClassicMutation : IMutationAlgorithm
    {
        private double mutationChance;
        private Random random;

        public ClassicMutation(double mutationChance)
        {
            this.mutationChance = mutationChance;
            this.random = new Random();
        }

        public IIndividual Mutate(IIndividual individual)
        {
            var binary = individual.Bits;
            for (int i = 0; i < individual.BinaryLength; i++)
            {
                var mutate = random.NextDouble() < mutationChance;
                if (mutate)
                {
                    binary.Revert(i);
                }
            }

            var newIndividual = individual.Clone();
            newIndividual.Update(binary);

            return newIndividual;
        }
    }
}
