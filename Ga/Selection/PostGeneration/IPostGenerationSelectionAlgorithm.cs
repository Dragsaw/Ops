using Ga.Individuals;
using System.Collections.Generic;

namespace Ga.Selection.PostGeneration
{
    public interface IPostGenerationSelectionAlgorithm
    {
        IEnumerable<IIndividual> Select(IEnumerable<IIndividual> children);
    }
}