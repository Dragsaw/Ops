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
    public class ParallelGeneticAlgorithm
    {
        private int currentGeneration;
        private readonly IInitializationAlgorithm initialization;
        private readonly ISelectionAlgorithm selection;
        private readonly ISelectionAlgorithm randomSelection = new RandomSelectionAlgorithm();
        private readonly IParingAlgorithm paring;
        private readonly ICrossoverAlgorithm crossover;
        private readonly IMutationAlgorithm mutation;
        private readonly IPostGenerationSelectionAlgorithm postGenerationSelection;
        private readonly Action<IIndividual> healthAction;
        private readonly int populationSize;
        private readonly IChromosome[] genome;
        private readonly double mutationChance;
        private readonly int? returnIndividualsCount;
        private readonly object syncToken = new object();
        private List<IIndividual> population;
        
        public LinkedList<Iteration> History { get; }
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

            History = new LinkedList<Iteration>();
        }

        public void Run()
        {
            currentGeneration++;
            History.AddLast(new Iteration());
            if (History.Count == 1)
            {
                population = initialization.Initialize(populationSize, genome).ToList();
                population.Where(x => x.IsHealthy).AsParallel().ForAll(this.healthAction);
                History.Last.Value.InitialPopulation = population;
                return;
            }

            population = selection.Select(population, populationSize).ToList();
            History.Last.Value.InitialPopulation = population;
            var tasks = new Task<IEnumerable<IIndividual>>[population.Count / 2];
            for (int i = 0; i < population.Count / 2; i++)
            {
                tasks[i] = Task.Run(() => RunProcess());
            }

            Task.WhenAll(tasks).Wait();

            population = tasks.SelectMany(x => x.Result).Distinct().ToList();
            var best = this.BestIndividual;
            if (population.Contains(best) == false)
            {
                population.Add(best);
            }

            History.Last.Value.PostGenerationSelected = population;
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
            var selected = randomSelection
                .Select(population, 4);
            // todo: мутация на родителях или потомках
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

            return postGenerationSelection.Select(children, returnIndividualsCount);
        }
    }
}
