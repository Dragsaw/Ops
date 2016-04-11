using Ga.Chromosomes;
using Ga.Crossover;
using Ga.Individuals;
using Ga.Infrastructure;
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
        public List<IIndividual> History { get; set; }

        public TwoParamsAlgotirhm(TwoParamsAlgorithmParams param) :
            this(param.XUpper, param.XLower, param.YUpper, param.YLower, param.XScale, param.YScale, param.InitSize, param.PopulationSize, param.MutationChance)
        {
        }

        public TwoParamsAlgotirhm(double xUpper, double xLower, double yUpper, double yLower, int xScale, int yScale, int initSize, int populationSize, double mutationChance)
        {
            History = new List<IIndividual>();
            X = new Chromosome { LowerLimit = xLower, UpperLimit = xUpper, Name = "X", Scale = xScale };
            Y = new Chromosome { LowerLimit = yLower, UpperLimit = yUpper, Name = "Y", Scale = yScale };
            algorithm = new ParallelGeneticAlgorithm(
                new RandomInitializationAlgorithm(initSize, X, Y),
                new RandomSelectionAlgorithm(2),
                new RandomParingAlgotrithm(2),
                new SinglePointCrossoverAlgorithm(5),
                new ClassicMutation(mutationChance),
                x => x.Health = x.Genome[0].Value + x.Genome[1].Value,
                populationSize);
            History.AddRange(algorithm.Population);
            algorithm.NewIndividualsAdded += Algorithm_NewIndividualsAdded;
        }

        private void Algorithm_NewIndividualsAdded(object sender, IndividualsEventArgs e)
        {
            History.AddRange(e.NewIndividuals);
        }

        public IEnumerable<IndividualViewModel> Run()
        {
            algorithm.Run();
            return Population;
        }
    }
}
