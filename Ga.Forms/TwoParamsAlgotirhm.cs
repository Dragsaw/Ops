using Ga.Chromosomes;
using Ga.Crossover;
using Ga.Individuals;
using Ga.Initialization;
using Ga.Mutation;
using Ga.Paring;
using Ga.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ga.Forms
{
    public class TwoParamsAlgotirhm
    {
        private ParallelGeneticAlgorithm algorithm;

        public IChromosome X { get; private set; }
        public IChromosome Y { get; private set; }

        public IEnumerable<IndividualViewModel> Population { get { return algorithm.Population.Select(x => new IndividualViewModel(x)); } }

        public TwoParamsAlgotirhm(double xUpper, double xLower, double yUpper, double yLower, int xScale, int yScale)
        {
            X = new Chromosome { LowerLimit = xLower, UpperLimit = xUpper, Name = "X", Scale = xScale };
            Y = new Chromosome { LowerLimit = yLower, UpperLimit = yUpper, Name = "Y", Scale = yScale };
            algorithm = new ParallelGeneticAlgorithm(
                new RandomInitializationAlgorithm(8, X, Y),
                new RandomSelectionAlgorithm(2),
                new RandomParingAlgotrithm(2),
                new SinglePointCrossoverAlgorithm(2),
                new ClassicMutation(0.2),
                x => x.Health = x.Genome[0].Value + x.Genome[1].Value);
        }

        public IEnumerable<IndividualViewModel> Run()
        {
            algorithm.Run();
            return Population;
        }
    }
}
