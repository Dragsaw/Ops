using Ga.Individuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Paring
{
    public interface IParingAlgorithm
    {
        IPare Pare(IEnumerable<IIndividual> individuals);
    }
}
