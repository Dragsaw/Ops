using Ga.Crossover;
using Ga.Individuals;
using Ga.Initialization;
using Ga.Mutation;
using Ga.Paring;
using Ga.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ga
{
    public class Algorithm
    {
        private int currentGeneration = 1;
        private IInitializationAlgorithm initialization;
        private ISelectionAlgorithm selection;
        private IParingAlgorithm paring;
        private ICrossoverAlgorithm crossover;
        private IMutationAlgorithm mutation;
        private Action<IIndividual> healthAction;
        private List<IIndividual> population;

        public IEnumerable<IIndividual> Population { get { return population; } }

        public Algorithm(IInitializationAlgorithm initialization, ISelectionAlgorithm selection, IParingAlgorithm paring,
            ICrossoverAlgorithm crossover, IMutationAlgorithm mutation, Action<IIndividual> healthAction)
        {
            this.initialization = initialization;
            this.selection = selection;
            this.paring = paring;
            this.crossover = crossover;
            this.mutation = mutation;
            this.healthAction = healthAction;

            population = new List<IIndividual>();
            population.AddRange(initialization.Initialize());
            population.ForEach(healthAction);
        }

        public void Run()
        {
            currentGeneration++;
            population = selection.Select(Population.Where(x => x.IsHealthy)).ToList();
            var paredIndividuals = paring.Pare(population);
            foreach (var pare in paredIndividuals)
            {
                var child = crossover.Crossover(pare);
                child.Generation = currentGeneration;
                healthAction(child);
                population.Add(child);
                var mutant = mutation.Mutate(child);
                mutant.Generation = currentGeneration;
                healthAction(mutant);
                population.Add(mutant);
            }
        }

        public void Solve(int count)
        {
            int iteration = 0;
            while (iteration < count && population.Count > 0)
            {
                Run();
            }
        }
    }
}
