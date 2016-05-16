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
using Jace;
using Ls;
using Ls.Infrastructure;
using Point = Ls.Infrastructure.Point;

namespace Gapp
{
    public partial class LocalSearchForm : Form
    {
        private AlgorithmFactory algorithmFactory = new AlgorithmFactory();
        private ParallelGeneticAlgorithm algorithm;
        private AlgorithmInfo algorithmInfo;
        private OptimizationAlgorithmFactory optimizationFactory = new OptimizationAlgorithmFactory();
        private readonly CalculationEngine engine = new CalculationEngine();
        private LinkedListNode<Iteration> currentIteration;
        private Point upperLimit;
        private Point lowerLimit;
        private Func<double, double, double> function;
        private Dictionary<string, OptimizationAlgorithm> optimizationsLog = new Dictionary<string, OptimizationAlgorithm>();

        public LocalSearchForm(AlgorithmInfo info)
        {
            InitializeComponent();
            algorithmInfo = info.Copy();
            algorithmInfo.MutationAlgorithmType = typeof(ClassicDecimalMutation);
            algorithmInfo.CrossoverAlgorithmType = info.Crossover == CrossoverAlgorithms.SinglePoint
                ? typeof(DecimalSinglePointCrossoverAlgorithm)
                : typeof(DecimalDoublePointCrossoverAlgorithm);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupFunction.Controls)
            {
                if (item is Button == false)
                {
                    item.Enabled = false;
                }
            }

            if (algorithm == null)
            {
                algorithm = CreateAlgorithm();
                upperLimit = new Point { X = (double)numMaxX.Value, Y = (double)numMaxY.Value };
                lowerLimit = new Point { X = (double)numMinX.Value, Y = (double)numMinY.Value };
                function = (Func<double, double, double>)engine.Formula(textBoxFunction.Text)
                    .Parameter("x1", DataType.FloatingPoint)
                    .Parameter("x2", DataType.FloatingPoint)
                    .Result(DataType.FloatingPoint)
                    .Build();
            }

            algorithm.Run();
            currentIteration = currentIteration ?? algorithm.History.First;
            ShowOtherIteration(new Button(), null);
        }

        private void HealthAction(IIndividual individual)
        {
            var optimization = optimizationFactory.Create(individual, upperLimit, lowerLimit, function);
            optimization.Run();
            // todo: change this
            individual.Health = -optimization.Points.Min(point => point.Z);
            lock (optimizationsLog)
            {
                var key = string.Format("{1}.{2}{3}", algorithm.History.Count - 1, individual.Generation, individual.Id, individual.IsMutant ? "m" : string.Empty);
                if (optimizationsLog.ContainsKey(key) == false)
                {
                    optimizationsLog.Add(
                        key,
                        optimization);
                }
            }
        }

        private ParallelGeneticAlgorithm CreateAlgorithm()
        {
            #region Chromosomes
            var initialization = new Chromosome
            {
                Name = "Initialization",
                LowerLimit = 0,
                UpperLimit = Enum.GetValues(typeof(Ls.Infrastructure.InitializationAlgorithms)).Length,
                Scale = 0
            };

            var selection = new Chromosome
            {
                Name = "Selection",
                LowerLimit = 0,
                UpperLimit = Enum.GetValues(typeof(Ls.Infrastructure.SelectionAlgorithms)).Length,
                Scale = 0
            };

            var localSearchAlgorithm = new Chromosome
            {
                Name = "Search",
                LowerLimit = 0,
                UpperLimit = Enum.GetValues(typeof(LocalSearchAlgorithms)).Length,
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
                GetId(individual),
                string.Format("{0} + {1}", GetId(individual.Parents.First) ?? string.Empty, GetId(individual.Parents.Second) ?? string.Empty),
                ((Ls.Infrastructure.InitializationAlgorithms)individual.Genome.First(x => x.Name == "Initialization").Value).ToString(),
                ((Ls.Infrastructure.SelectionAlgorithms)individual.Genome.First(x => x.Name == "Selection").Value).ToString(),
                ((Ls.Infrastructure.LocalSearchAlgorithms)individual.Genome.First(x => x.Name == "Search").Value).ToString(),
                individual.Genome.First(x => x.Name == "N").Value,
                individual.Genome.First(x => x.Name == "n").Value,
                ((RunOptions)individual.Genome.First(x => x.Name == "Run").Value).ToString(),
                -individual.Health,
                string.Join("", individual.Genome.Select(x => x.Value))
                );
        }

        private static string GetId(IIndividual individual)
        {
            if (individual == null)
            {
                return null;
            }

            return string.Format("{0}.{1}{2}", individual.Generation, individual.Id, individual.IsMutant ? "m" : string.Empty);
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

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            var selected = grid.SelectedRows[0];
            var index = algorithm.History.IndexOf(currentIteration);
            var optimization = optimizationsLog[string.Format("{1}", index, selected.Cells["Id"].Value)];
            var detailsForm = new OptimizationForm(optimization);
            detailsForm.Show(this);
        }
    }
}
