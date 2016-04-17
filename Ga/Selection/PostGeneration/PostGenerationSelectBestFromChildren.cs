using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;

namespace Ga.Selection.PostGeneration
{
    public class PostGenerationSelectBestFromChildren : IPostGenerationSelectionAlgorithm
    {
        private readonly int count;

        public PostGenerationSelectBestFromChildren(int count)
        {
            this.count = count;
        }

        public IEnumerable<IIndividual> Select(IEnumerable<IIndividual> children)
        {
            return children
                .Where(child => child.IsHealthy)
                .OrderByDescending(child => child.Health)
                .ThenBy(child => child.Id)
                .Take(count);
        }
    }
}
