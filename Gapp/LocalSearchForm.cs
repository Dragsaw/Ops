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
using Ga.Mutation;
using Gapp.Infrastructure.Ls;
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
            groupFunction.Enabled = false;
            buttonRun.Enabled = true;

            if (algorithm == null)
            {
                algorithm = CreateAlgorithm();
            }

            algorithm.Run();
        }

        private void HealthAction(IIndividual individual)
        {
            // todo: get values from UI
            var optimization = optimizationFactory.Create(individual, null, null, null);
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
                UpperLimit = Enum.GetValues(typeof(InitializationAlgorithms)).Length,
                Scale = 0
            };

            var selection = new Chromosome
            {
                Name = "Selection",
                LowerLimit = 0,
                UpperLimit = Enum.GetValues(typeof(SelectionAlgorithms)).Length,
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
    }
}
