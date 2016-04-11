using Ga.Individuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Infrastructure
{
    public class IndividualsEventArgs : EventArgs
    {
        public IEnumerable<IIndividual> NewIndividuals { get; set; }
    }
}
