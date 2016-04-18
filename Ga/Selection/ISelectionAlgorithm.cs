using Ga.Individuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Selection
{
    public interface ISelectionAlgorithm
    {
        IEnumerable<IIndividual> Select(IEnumerable<IIndividual> individuals, int take);
    }
}
