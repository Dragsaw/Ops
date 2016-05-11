using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ga;
using Ga.Chromosomes;
using Ga.Crossover;
using Ga.Individuals;
using Ga.Infrastructure;
using Ga.Mutation;
using Gapp.Infrastructure;
using Gapp.Management;
using Ls.Infrastructure;

namespace Gapp
{
    public partial class LocalSearchForm : Form
    {
        private AlgorithmFactory algorithmFactory = new AlgorithmFactory();
        private ParallelGeneticAlgorithm algorithm;
        private AlgorithmInfo algorithmInfo;
        private OptimizationAlgorithmFactory optimizationFactory = new OptimizationAlgorithmFactory();
        private LinkedListNode<Iteration> currentIteration;

        public LocalSearchForm(AlgorithmInfo info)
        {
            InitializeComponent();
            algorithmInfo = info.Copy();
            algorithmInfo.MutationAlgorithmType = typeof(ClassicDecimalMutation);
            algorithmInfo.CrossoverAlgorithmType = info.Crossover == Infrastructure.CrossoverAlgorithms.SinglePoint
                ? typeof(DecimalSinglePointCrossoverAlgorithm)
                : typeof(DecimalDoublePointCrossoverAlgorithm);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupFunction.Controls)
            {
                item.Enabled = false;
            }

            buttonRun.Enabled = true;

            if (algorithm == null)
            {
                algorithm = CreateAlgorithm();
            }

            algorithm.Run();
            currentIteration = algorithm.History.First;
            ShowOtherIteration(new Button(), null);
        }

        private void HealthAction(IIndividual individual)
        {
            // todo: get values from UI
            var optimization = optimizationFactory.Create(individual, new Ls.Infrastructure.Point { X = 10, Y = 10 }, new Ls.Infrastructure.Point { X = 0, Y = 0 }, (x, y) => x + y);
            optimization.Run();
            // todo: change this
            individual.Health = -optimization.Points.Min(point => point.Z);
        }

        private ParallelGeneticAlgorithm CreateAlgorithm()
        {
            #region Chromosomes
            var initialization = new Chromosome
            {
                Name = "Initialization",
                LowerLimit = 0,
                UpperLimit = Enum.GetValues(typeof(LsInitializationAlgorithms)).Length,
                Scale = 0
            };

            var selection = new Chromosome
            {
                Name = "Selection",
                LowerLimit = 0,
                UpperLimit = Enum.GetValues(typeof(LsSelectionAlgorithms)).Length,
                Scale = 0
            };

            var localSearchAlgorithm = new Chromosome
            {
                Name = "Search",
                LowerLimit = 0,
                UpperLimit = Enum.GetValues(typeof(LsLocalSearchAlgorithms)).Length,
                Scale = 0
            };

            // todo: предусмотреть ситуацию, когда N > n
            var initialCount = new Chromosome
            {
                Name = "N",
                LowerLimit = 1,
                UpperLimit = 50,
                Scale = 0
            };

            var selectedCount = new Chromosome
            {
                Name = "n",
                LowerLimit = 1,
                UpperLimit = 50,
                Scale = 0
            };

            var runCondition = new Chromosome
            {
                Name = "Run",
                LowerLimit = 0,
                UpperLimit = Enum.GetValues(typeof(RunOptions)).Length,
                Scale = 0
            };
            #endregion

            return algorithmFactory.Create(
                algorithmInfo,
                HealthAction,
                initialization,
                selection,
                localSearchAlgorithm,
                initialCount,
                selectedCount,
                runCondition);
        }

        private void AddIndividual(IIndividual individual)
        {
            grid.Rows.Add(
                string.Format("{0}.{1}{2}", individual.Generation, individual.Id, individual.IsMutant ? "m" : string.Empty),
                ((LsInitializationAlgorithms)individual.Genome.First(x => x.Name == "Initialization").Value).ToString(),
                ((LsSelectionAlgorithms)individual.Genome.First(x => x.Name == "Selection").Value).ToString(),
                ((LsLocalSearchAlgorithms)individual.Genome.First(x => x.Name == "Search").Value).ToString(),
                individual.Genome.First(x => x.Name == "N").Value,
                individual.Genome.First(x => x.Name == "n").Value,
                ((RunOptions)individual.Genome.First(x => x.Name == "Run").Value).ToString(),
                -individual.Health,
                string.Join("", individual.Genome.Select(x => x.Value))
                );
        }

        private void ShowOtherIteration(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text == "Next")
            {
                currentIteration = currentIteration.Next;
            }
            else if (button.Text == "Previous")
            {
                currentIteration = currentIteration.Previous;
            }
            else if (button.Text == ">>")
            {
                currentIteration = currentIteration.List.Last;
            }
            else if (button.Text == "<<")
            {
                currentIteration = currentIteration.List.First;
            }

            buttonFirst.Enabled = buttonPrevious.Enabled = currentIteration.Previous != null;
            buttonLast.Enabled = buttonNext.Enabled = currentIteration.Next != null;

            grid.ShowIteration(currentIteration.Value, AddIndividual);
        }
    }
}
