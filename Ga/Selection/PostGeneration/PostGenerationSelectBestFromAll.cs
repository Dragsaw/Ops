using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;

namespace Ga.Selection.PostGeneration
{
    public class PostGenerationSelectBestFromAll : IPostGenerationSelectionAlgorithm
    {
        private readonly int count;

        public PostGenerationSelectBestFromAll(int count)
        {
            this.count = count;
        }

        public IEnumerable<IIndividual> Select(IEnumerable<IIndividual> children)
        {
            return children
                .Aggregate(new List<IIndividual>(), (list, child) =>
                {
                    if (child.IsHealthy)
                    {
                        list.Add(child);
                    }

                    list.Add(child.Parents.First);
                    if (child.IsMutant == false)
                    {
                        list.Add(child.Parents.Second);
                    }

                    return list;
                })
                .OrderByDescending(ind => ind.Health)
                .ThenBy(ind => ind.Id)
                .Take(count);
        }
    }
}
