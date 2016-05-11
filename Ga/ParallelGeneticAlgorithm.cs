using Ga.Chromosomes;
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
    // todo: add iteration details
    // todo: fix post generation selection
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
        private IChromosome[] genome;
        private double mutationChance;
        private int? returnIndividualsCount;
        private object syncToken = new object();

        public IEnumerable<IIndividual> Population { get { return population; } }
        public LinkedList<Iteration> History { get; private set; }
        public IIndividual BestIndividual
        {
            get
            {
                return population.OrderByDescending(x => x.Health).ThenBy(x => x.Id).First(x => x.IsHealthy);
            }
        }

        public ParallelGeneticAlgorithm(
            IInitializationAlgorithm initialization,
            ISelectionAlgorithm selection,
            IParingAlgorithm paring,
            ICrossoverAlgorithm crossover,
            IMutationAlgorithm mutation,
            IPostGenerationSelectionAlgorithm postGenerationSelection,
            Action<IIndividual> healthAction,
            int populationSize,
            double mutationChance,
            int? returnIndividualsCount,
            params IChromosome[] chromosomes)
        {
            this.initialization = initialization;
            this.selection = selection;
            this.paring = paring;
            this.crossover = crossover;
            this.mutation = mutation;
            this.postGenerationSelection = postGenerationSelection;
            this.healthAction = healthAction;
            this.populationSize = populationSize;
            this.genome = chromosomes;
            this.mutationChance = mutationChance;
            this.returnIndividualsCount = returnIndividualsCount;

            this.History = new LinkedList<Iteration>();
        }

        public void Run()
        {
            History.AddLast(new Iteration());
            if (this.History.Count == 1)
            {
                population = initialization.Initialize(populationSize, genome).ToList();
                population.Where(x => x.IsHealthy).AsParallel().ForAll(this.healthAction);
                History.Last.Value.InitialPopulation = this.Population;
                return;
            }

            population = population
                .Where(x => x.IsHealthy)
                .OrderByDescending(x => x.Health)
                .ThenBy(x => x.Id)
                .Take(populationSize)
                .ToList();
            History.Last.Value.InitialPopulation = this.Population;
            currentGeneration++;
            var tasks = new Task<IEnumerable<IIndividual>>[population.Count / 2];
            for (int i = 0; i < population.Count / 2; i++)
            {
                tasks[i] = new Task<IEnumerable<IIndividual>>(RunProcess);
                tasks[i].Start();
            }

            Task.WaitAll(tasks);
            var best = this.BestIndividual;
            population = tasks.SelectMany(x => x.Result).Distinct().ToList();
            if (population.Contains(best) == false)
            {
                population.Add(best);
            }

            History.Last.Value.PostGenerationSelected = this.Population;
        }

        public void Solve(Func<ParallelGeneticAlgorithm, bool> condition)
        {
            do
            {
                Run();
            }
            while (condition(this));
        }

        private IEnumerable<IIndividual> RunProcess()
        {
            var firstSelection = selection
                .Select(population, 2)
                .ToList();
            var secondSelection = selection
                .Select(population, 2)
                .ToList();
            var selected = firstSelection.Concat(secondSelection);
            // todo: мутация на родителях или потомках
            // todo: изменить разбитие на пары
            var parents = paring.Pare(selected);
            var children = crossover.Crossover(parents, currentGeneration).ToList();
            var mutants = children
                .Select(x => mutation.Mutate(x, mutationChance))
                .Where(mutant => mutant != null)
                .ToArray();
            children.AddRange(mutants);
            foreach (var child in children)
            {
                if (child.IsHealthy)
                {
                    healthAction(child);
                }
                else
                {
                    child.Health = double.NaN;
                }
            }

            lock (syncToken)
            {
                History.Last.Value.Children.AddRange(children);
            }

            return postGenerationSelection.Select(children, returnIndividualsCount).Where(x => x != null);
        }
    }
}
