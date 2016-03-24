using Ga.Chromosomes;
using Ga.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Individuals
{
    public interface IIndividual : IBinaryEntity
    {
        IList<IChromosome> Genome { get; set; }
        int Id { get; set; }
        int Generation { get; set; }
        double Health { get; set; }
        bool IsHealthy { get; }
        IIndividual Clone();
        string Label { get; }
    }
}
