using Ga.Crossover;
using Ga.Individuals;
using Ga.Initialization;
using Ga.Mutation;
using Ga.Paring;
using Ga.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ga
{
    public class ParallelGeneticAlgorithm
    {
        private int currentGeneration = 1;
        private readonly int numberOfIndividuals;
        private IInitializationAlgorithm initialization;
        private ISelectionAlgorithm selection;
        private IParingAlgorithm paring;
        private ICrossoverAlgorithm crossover;
        private IMutationAlgorithm mutation;
        private Action<IIndividual> healthAction;
        private List<IIndividual> population;

        public IEnumerable<IIndividual> Population { get { return population; } }

        public ParallelGeneticAlgorithm(IInitializationAlgorithm initialization, ISelectionAlgorithm selection, IParingAlgorithm paring,
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
            population.AsParallel().ForAll(this.healthAction);
            numberOfIndividuals = population.Count;
        }

        public void Run()
        {
            currentGeneration++;
            var tasks = new Task<IEnumerable<IIndividual>>[numberOfIndividuals / 2];
            for (int i = 0; i < numberOfIndividuals / 2; i++)
            {
                tasks[i] = new Task<IEnumerable<IIndividual>>(RunProcess);
                tasks[i].Start();
            }

            Task.WaitAll(tasks);
            var resultIndividuals = tasks.SelectMany(x => x.Result);
            population.AddRange(resultIndividuals);
            population = population
                .Where(x => x.IsHealthy)
                .OrderByDescending(x => x.Health)
                .ThenBy(x => x.Id)
                .Take(numberOfIndividuals)
                .ToList();
        }

        public void Solve(Func<ParallelGeneticAlgorithm, bool> condition)
        {
            while (condition(this))
            {
                Run();
            }
        }

        private IEnumerable<IIndividual> RunProcess()
        {
            List<IIndividual> selected;
            lock (population)
            {
                selected = selection.Select(population).ToList();
                population.Remove(selected.First());
                population.Remove(selected.Last());
            }

            var pare = new Pare { First = selected.First(), Second = selected.Last() };
            var child = crossover.Crossover(pare, currentGeneration);
            var mutant = mutation.Mutate(child);
            healthAction(child);
            selected.Add(child);
            if (mutant != null)
            {
                healthAction(mutant);
                selected.Add(mutant);
            }

            return selected;
        }
    }
}
