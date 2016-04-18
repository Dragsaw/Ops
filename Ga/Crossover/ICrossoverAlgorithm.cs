using Ga.Individuals;
using Ga.Paring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Crossover
{
    public interface ICrossoverAlgorithm
    {
        IEnumerable<IIndividual> Crossover(IPare pare, IEnumerable<int> points, int generation);
    }
}
