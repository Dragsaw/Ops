using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Paring;

namespace Ga.Crossover
{
    public class DecimalSinglePointCrossoverAlgorithm : ICrossoverAlgorithm
    {
        public IEnumerable<IIndividual> Crossover(IPare pare, int generation)
        {
            var ind1 = pare.First.Clone();
            var ind2 = pare.Second.Clone();
            var point = ind1.Genome.Count / 2;
            ind1.Genome = pare.First.Genome.Take(point).Concat(pare.Second.Genome.Skip(point)).ToList();
            ind2.Genome = pare.Second.Genome.Take(point).Concat(pare.First.Genome.Skip(point)).ToList();
            return new[] { ind1, ind2 };
        }
    }
}
