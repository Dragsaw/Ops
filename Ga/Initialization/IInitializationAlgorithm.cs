using Ga.Chromosomes;
using Ga.Individuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Initialization
{
    public interface IInitializationAlgorithm
    {
        IEnumerable<IIndividual> Initialize(int individualsCount, params IChromosome[] chromosomes);
    }
}
