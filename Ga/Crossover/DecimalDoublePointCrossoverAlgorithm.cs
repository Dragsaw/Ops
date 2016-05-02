using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Paring;

namespace Ga.Crossover
{
    public class DecimalDoublePointCrossoverAlgorithm : ICrossoverAlgorithm
    {
        public IEnumerable<IIndividual> Crossover(IPare pare, int generation)
        {
            var ind1 = pare.First.Clone();
            var ind2 = pare.Second.Clone();
            var point1 = ind1.Genome.Count / 3;
            var point2 = ind1.Genome.Count * 2 / 3;
            ind1.Genome = pare.First.Genome.Take(point1).Concat(pare.Second.Genome.Skip(point1).Take(point2 - point1)).Concat(pare.First.Genome.Skip(point2)).ToList();
            ind1.Genome = pare.Second.Genome.Take(point1).Concat(pare.First.Genome.Skip(point1).Take(point2 - point1)).Concat(pare.Second.Genome.Skip(point2)).ToList();
            return new[] { ind1, ind2 };
        }
    }
}
