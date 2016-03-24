using Ga.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Chromosomes
{
    public interface IChromosome : IBinaryEntity
    {
        double UpperLimit { get; set; }
        double LowerLimit { get; set; }
        double Value { get; set; }
        string Name { get; set; }
        bool IsValid { get; }
        int Scale { get; set; }
        IChromosome Clone();
    }
}
