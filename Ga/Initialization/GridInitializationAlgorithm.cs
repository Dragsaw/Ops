using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Chromosomes;
using Ga.Individuals;
using Ga.Infrastructure;

namespace Ga.Initialization
{
    public class GridInitializationAlgorithm : IInitializationAlgorithm
    {
        private readonly IndividualsFactory individualsFactory;

        public GridInitializationAlgorithm(IndividualsFactory individualsFactory)
        {
            this.individualsFactory = individualsFactory;
        }

        public IEnumerable<IIndividual> Initialize(int individualsCount, params IChromosome[] chromosomes)
        {
            var result = new IIndividual[individualsCount];
            var sequences = new double[chromosomes.Length][];
            var rowLength = (int)Math.Pow(individualsCount, 1.0 / chromosomes.Length);
            for (int i = 0; i < chromosomes.Length; i++)
            {
                var step = rowLength == 1 ? 1 : (chromosomes[i].UpperLimit - chromosomes[i].LowerLimit) / (rowLength - 1);
                sequences[i] = new double[rowLength];
                for (int j = 0; j < rowLength; j++)
                {
                    sequences[i][j] = Math.Round(chromosomes[i].LowerLimit + step * (j), chromosomes[i].Scale);
                }
            }

            var combinations = CartesianProduct(sequences);
            var combinationsCount = combinations.Count();
            for (int i = 0; i < individualsCount; i++)
            {
                var individual = individualsFactory.Create();
                individual.Generation = 1;
                var combinationIndex = i % combinationsCount;
                for (int j = 0; j < chromosomes.Length; j++)
                {
                    var newChromosome = chromosomes[j].Clone();
                    newChromosome.Value = combinations.ElementAt(combinationIndex).ElementAt(j);
                    individual.Genome.Add(newChromosome);
                }

                result[i] = individual;
            }

            return result;
        }

        private IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(emptyProduct, (accumulator, sequence) =>
                 from accseq in accumulator
                 from item in sequence
                 select accseq.Concat(new[] { item }));
        }
    }
}
