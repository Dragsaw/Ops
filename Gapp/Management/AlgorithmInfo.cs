using Ga;
using Ga.Crossover;
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

namespace Gapp.Management
{
    public class AlgorithmInfo
    {
        private ParallelGeneticAlgorithm algorithm;

        public int PopulationSize { get; set; }
        public SelectionAlgorithms Selection { get; set; }
        public InitializationAlgorithms Initialization { get; set; }
        public CrossoverAlgorithms Crossover { get; set; }
        public int[] CrossoverPoints { get; set; }
        public double MutationChance { get; set; }
        public PostGenerationSelectionAlgorithms PostGenerationSelection { get; set; }
        public double? Rating { get; set; }
        public ParallelGeneticAlgorithm Algorithm
        {
            get
            {
                if (algorithm == null)
                {
                    algorithm = this.Initialize();
                }

                return algorithm;
            }
        }

        public string SelectionName { get { return this.Selection.ToString(); } }
        public string InitializationName { get { return this.Initialization.ToString(); } }
        public string CrossoverName { get { return this.Crossover.ToString(); } }
        public string CrossoverPointsName { get { return string.Join(",", this.CrossoverPoints); } }
        public string PostGenerationSelectionName { get { return this.PostGenerationSelection.ToString(); } }

        private ParallelGeneticAlgorithm Initialize()
        {
            var initialization = Activator.CreateInstance(this.Initialization.GetAlgorithmType()) as IInitializationAlgorithm;
            var selection = Activator.CreateInstance(this.Selection.GetAlgorithmType()) as ISelectionAlgorithm;
            var crossover = Activator.CreateInstance(this.Crossover.GetAlgorithmType()) as ICrossoverAlgorithm;
            var postGenerationSelection = Activator.CreateInstance(this.PostGenerationSelection.GetAlgorithmType()) as IPostGenerationSelectionAlgorithm;

            return new ParallelGeneticAlgorithm(
                initialization,
                selection,
                new RandomParingAlgorithm(),
                crossover,
                new ClassicMutation(this.MutationChance),
                postGenerationSelection,
                null,
                this.PopulationSize);
        }
    }
}
