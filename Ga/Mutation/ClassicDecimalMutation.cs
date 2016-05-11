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
    public class ClassicDecimalMutation : IMutationAlgorithm
    {
        private readonly IndividualsFactory individualsFactory;
        private Random random = new Random(DateTime.Now.Millisecond);

        public ClassicDecimalMutation(IndividualsFactory individualsFactory)
        {
            this.individualsFactory = individualsFactory;
        }

        public IIndividual Mutate(IIndividual individual, double mutationChance)
        {
            var newIndividual = individualsFactory.Create(individual);
            foreach (var chromosome in newIndividual.Genome)
            {
                var mutate = random.NextDouble() < mutationChance;
                if (mutate == false)
                {
                    continue;
                }

                newIndividual.IsMutant = true;
                chromosome.Value = random.Next((int)chromosome.LowerLimit, (int)chromosome.UpperLimit);
            }

            if (newIndividual.IsMutant == false)
            {
                return null;
            }

            newIndividual.Id = individual.Id;
            newIndividual.Parents = new Pare { First = individual, Second = null };
            return newIndividual;
        }
    }
}
