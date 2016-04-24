using Ga;
using Ga.Chromosomes;
using Ga.Crossover;
using Ga.Individuals;
using Ga.Initialization;
using Ga.Mutation;
using Ga.Paring;
using Ga.Selection;
using Ga.Selection.PostGeneration;
using Gapp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gapp.Management
{
    public class AlgorithmFactory
    {
        public ParallelGeneticAlgorithm Create(AlgorithmInfo info, Action<IIndividual> healthAction, params IChromosome[] chromosomes)
        {
            var initialization = Activator.CreateInstance(info.Initialization.GetAlgorithmType()) as IInitializationAlgorithm;
            var selection = Activator.CreateInstance(info.Selection.GetAlgorithmType()) as ISelectionAlgorithm;
            var crossover = Activator.CreateInstance(info.Crossover.GetAlgorithmType()) as ICrossoverAlgorithm;
            var postGenerationSelection = Activator.CreateInstance(info.PostGenerationSelection.GetAlgorithmType()) as IPostGenerationSelectionAlgorithm;

            return new ParallelGeneticAlgorithm(
                initialization,
                selection,
                new RandomParingAlgorithm(),
                crossover,
                new ClassicMutation(),
                postGenerationSelection,
                healthAction,
                info.PopulationSize,
                info.MutationChance,
                // todo: replace with actual number
                null,
                chromosomes);
        }
    }
}
