using Ga.Crossover;
using Ga.Individuals;
using Ga.Infrastructure;
using Ga.Initialization;
using Ga.Mutation;
using Ga.Paring;
using Ga.Selection;
using Ga.Selection.PostGeneration;
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
        private IPostGenerationSelectionAlgorithm postGenerationSelection;
        private Action<IIndividual> healthAction;
        private List<IIndividual> population;
        private int populationSize;

        public event EventHandler<IndividualsEventArgs> NewIndividualsAdded;

        public IEnumerable<IIndividual> Population { get { return population; } }
        public IList<IEnumerable<IIndividual>> History { get; private set; }

        public ParallelGeneticAlgorithm(IInitializationAlgorithm initialization, ISelectionAlgorithm selection, IParingAlgorithm paring,
            ICrossoverAlgorithm crossover, IMutationAlgorithm mutation, IPostGenerationSelectionAlgorithm postGenerationSelection, Action<IIndividual> healthAction, int populationSize)
        {
            this.initialization = initialization;
            this.selection = selection;
            this.paring = paring;
            this.crossover = crossover;
            this.mutation = mutation;
            this.postGenerationSelection = postGenerationSelection;
            this.healthAction = healthAction;
            this.populationSize = populationSize;

            this.NewIndividualsAdded += SaveNewIndividuals;
            this.History = new List<IEnumerable<IIndividual>>();
        }

        public void Run()
        {
            if (this.History.Count == 0)
            {
                population = initialization.Initialize().ToList();
                population.AsParallel().ForAll(this.healthAction);
                NewIndividualsAdded(this, new IndividualsEventArgs { NewIndividuals = this.Population });
                return;
            }

            population = population
                .Where(x => x.IsHealthy)
                .OrderByDescending(x => x.Health)
                .ThenBy(x => x.Id)
                .Take(populationSize)
                .ToList();
            currentGeneration++;
            var tasks = new Task<IEnumerable<IIndividual>>[population.Count / 2];
            for (int i = 0; i < population.Count / 2; i++)
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
            var firstSelection = selection
                .Select(population)
                .ToList();
            var secondSelection = selection
                .Select(population)
                .ToList();
            var selected = firstSelection.Concat(secondSelection);
            // todo: мутация на родителях или потомках
            var parents = paring.Pare(selected);
            var children = crossover.Crossover(parents, currentGeneration).ToList();
            var mutants = children
                .Select(x => mutation.Mutate(x))
                .Where(mutant => mutant != null);
            children.AddRange(mutants);
            children.ForEach(healthAction);
            return postGenerationSelection.Select(children);
        }

        private void SaveNewIndividuals(object sender, IndividualsEventArgs e)
        {
            this.History.Add(e.NewIndividuals);
        }
    }
}
