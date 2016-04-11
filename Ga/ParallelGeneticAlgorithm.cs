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
using System.Threading.Tasks;

namespace Ga
{
    public class ParallelGeneticAlgorithm
    {
        private int currentGeneration = 1;
        private IInitializationAlgorithm initialization;
        private ISelectionAlgorithm selection;
        private IParingAlgorithm paring;
        private ICrossoverAlgorithm crossover;
        private IMutationAlgorithm mutation;
        private Action<IIndividual> healthAction;
        private List<IIndividual> population;
        private int populationSize;

        public event EventHandler<IndividualsEventArgs> NewIndividualsAdded;

        public IEnumerable<IIndividual> Population { get { return population; } }

        public ParallelGeneticAlgorithm(IInitializationAlgorithm initialization, ISelectionAlgorithm selection, IParingAlgorithm paring,
            ICrossoverAlgorithm crossover, IMutationAlgorithm mutation, Action<IIndividual> healthAction, int populationSize)
        {
            this.initialization = initialization;
            this.selection = selection;
            this.paring = paring;
            this.crossover = crossover;
            this.mutation = mutation;
            this.healthAction = healthAction;
            this.populationSize = populationSize;

            population = new List<IIndividual>();
            population.AddRange(initialization.Initialize());
            population.AsParallel().ForAll(this.healthAction);
        }

        public void Run()
        {
            population = population
                .Where(x => x.IsHealthy)
                .OrderByDescending(x => x.Health)
                .ThenBy(x => x.Id)
                .Take(populationSize)
                .ToList();
            currentGeneration++;
            var tasks = new Task<IEnumerable<IIndividual>>[populationSize / 2];
            for (int i = 0; i < populationSize / 2; i++)
            {
                tasks[i] = new Task<IEnumerable<IIndividual>>(RunProcess);
                tasks[i].Start();
            }

            Task.WaitAll(tasks);
            var resultIndividuals = tasks.SelectMany(x => x.Result);
            population.AddRange(resultIndividuals);
            NewIndividualsAdded(this, new IndividualsEventArgs { NewIndividuals = resultIndividuals });
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
            var selected = selection.Select(population).ToList();
            selected.AddRange(selection.Select(population));
            var bestOfSelected = selected.OrderByDescending(x => x.Health).ThenBy(x => x.Id).Take(2);

            var pare = new Pare { First = bestOfSelected.First(), Second = bestOfSelected.Last() };
            var children = crossover.Crossover(pare, currentGeneration);
            var mutants = children.Select(x => mutation.Mutate(x));

            foreach (var child in children)
            {
                healthAction(child);
            }

            selected.Clear();
            selected.AddRange(children);
            foreach (var mutant in mutants.Where(x => x != null))
            {
                healthAction(mutant);
                selected.Add(mutant);
            }

            return selected;
        }
    }
}
