using Ga.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Chromosomes
{
    /// <summary>Declares properties and methods of a chromosome.</summary>
    public interface IChromosome : IBinaryEntity
    {
        /// <summary>Gets or sets the upper limit of the value.</summary>
        double UpperLimit { get; set; }
        /// <summary>Gets or sets the lower limit of the value.</summary>
        double LowerLimit { get; set; }
        /// <summary>Gets or sets the value.</summary>
        double Value { get; set; }
        /// <summary>Gets or sets the name of the chromosome.</summary>
        string Name { get; set; }
        /// <summary>Indicates if chromosome contains a valid value.</summary>
        bool IsValid { get; }
        /// <summary>Gets or sets the number of decimal places of the value.</summary>
        int Scale { get; set; }
        /// <summary>
        /// Creates a deep copy of the object.
        /// </summary>
        /// <returns>Copy of the object.</returns>
        IChromosome Clone();
    }
}
