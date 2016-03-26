using Ga.Chromosomes;
using Ga.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Individuals
{
    /// <summary>Declares properies and methods of an individual.</summary>
    public interface IIndividual : IBinaryEntity
    {
        /// <summary>Gets of sets the set of chromosomes.</summary>
        IList<IChromosome> Genome { get; set; }
        /// <summary>Gets of sets the id of the individual.</summary>
        int Id { get; set; }
        /// <summary>Gets of sets the generation of the individual.</summary>
        int Generation { get; set; }
        /// <summary>Gets of sets the health value of the individual.</summary>
        double Health { get; set; }
        /// <summary>Indicates if individual is valid.</summary>
        bool IsHealthy { get; }
        /// <summary>Indicates if the individual is a mutant.</summary>
        bool IsMutant { get; set; }

        /// <summary>
        /// Creates a deep copy of the object.
        /// </summary>
        /// <returns>Copy of the object.</returns>
        IIndividual Clone();
    }
}
