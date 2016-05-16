using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;

namespace Ga.Selection
{
    public class TournamentSelectionAlgorithm : ISelectionAlgorithm
    {
        public IEnumerable<IIndividual> Select(IEnumerable<IIndividual> individuals, int take)
        {
            var groups = new Dictionary<int, List<IIndividual>>();
            var array = individuals.Where(i => i.IsHealthy).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                var key = i % take;
                if (groups.ContainsKey(key) == false)
                {
                    groups.Add(key, new List<IIndividual>());
                }

                groups[key].Add(array[i]);
            }

            return groups.Select(x => x.Value.OrderByDescending(i => i.Health).ThenBy(i => i.Id).First());
        }
    }
}
