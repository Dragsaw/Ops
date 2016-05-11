using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Paring;

namespace Ga.Infrastructure
{
    public class Iteration
    {
        public Iteration()
        {
            Children = new List<IIndividual>();
        }

        public IEnumerable<IIndividual> InitialPopulation { get; set; }
        public IEnumerable<IIndividual> Parents
        {
            get
            {
                return Children
                    .Where(x => x.IsMutant == false)
                    .SelectMany(x => new[] { x.Parents.First, x.Parents.Second })
                    .Where(x => x != null)
                    .Distinct();
            }
        }

        public List<IIndividual> Children { get; set; }
        public IEnumerable<IIndividual> PostGenerationSelected { get; set; }
    }
}
