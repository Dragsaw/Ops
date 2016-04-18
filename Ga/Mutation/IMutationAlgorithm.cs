using Ga.Individuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Mutation
{
    public interface IMutationAlgorithm
    {
        IIndividual Mutate(IIndividual individual, double mutationChance);
    }
}
