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
using Ga.Infrastructure;

namespace Gapp.Management
{
    public class AlgorithmInfo
    {
        private Type mutationAlgorithm = typeof(ClassicMutation);
        public int PopulationSize { get; set; }
        public SelectionAlgorithms Selection { get; set; }
        public InitializationAlgorithms Initialization { get; set; }
        public CrossoverAlgorithms Crossover { get; set; }
        public double MutationChance { get; set; }
        public PostGenerationSelectionAlgorithms PostGenerationSelection { get; set; }
        public double? Rating { get; set; }
        public ParallelGeneticAlgorithm Algorithm { get; set; }
        public Type CrossoverAlgorithmType { get; set; }
        public Mutate Mutate { get; set; }
        public Type MutationAlgorithmType
        {
            get { return mutationAlgorithm; }
            set { mutationAlgorithm = value; }
        }

        public string SelectionName { get { return this.Selection.ToString(); } }
        public string InitializationName { get { return this.Initialization.ToString(); } }
        public string CrossoverName { get { return this.Crossover.ToString(); } }
        public string PostGenerationSelectionName { get { return this.PostGenerationSelection.ToString(); } }
        public string MutateName { get { return this.Mutate.ToString(); } }

        public AlgorithmInfo Copy()
        {
            return MemberwiseClone() as AlgorithmInfo;
        }
    }
}
