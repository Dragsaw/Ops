using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Infrastructure;
using Ga.Paring;

namespace Ga.Crossover
{
    public class DecimalDoublePointCrossoverAlgorithm : ICrossoverAlgorithm
    {
        private readonly IndividualsFactory individualsFactory;

        public DecimalDoublePointCrossoverAlgorithm(IndividualsFactory individualsFactory)
        {
            this.individualsFactory = individualsFactory;
        }

        public IEnumerable<IIndividual> Crossover(IPare pare, int generation)
        {
            var ind1 = individualsFactory.Create(pare.First);
            var ind2 = individualsFactory.Create(pare.Second);
            ind1.Generation = generation;
            ind2.Generation = generation;
            var point1 = ind1.Genome.Count / 3;
            var point2 = ind1.Genome.Count * 2 / 3;
            ind1.Genome = pare.First.Genome.Take(point1).Concat(pare.Second.Genome.Skip(point1).Take(point2 - point1)).Concat(pare.First.Genome.Skip(point2)).ToList();
            ind1.Genome = pare.Second.Genome.Take(point1).Concat(pare.First.Genome.Skip(point1).Take(point2 - point1)).Concat(pare.Second.Genome.Skip(point2)).ToList();
            return new[] { ind1, ind2 };
        }
    }
}
