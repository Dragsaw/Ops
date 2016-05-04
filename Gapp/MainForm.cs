using Ga.Chromosomes;
using Ga.Individuals;
using Gapp.Infrastructure;
using Gapp.Management;
using Jace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gapp
{
    public partial class MainForm : Form
    {
        private readonly AlgorithmsGridView grid = new AlgorithmsGridView();
        private readonly AlgorithmFactory algorithmFactory = new AlgorithmFactory();
        private readonly CalculationEngine engine = new CalculationEngine();
        private Func<double, double, double> function;

        public MainForm()
        {
            InitializeComponent();

            listInitialization.DataSource = Enum.GetValues(typeof(InitializationAlgorithms));
            listSelection.DataSource = Enum.GetValues(typeof(SelectionAlgorithms));
            listPostGenerationSelection.DataSource = Enum.GetValues(typeof(PostGenerationSelectionAlgorithms));
            listCrossover.DataSource = Enum.GetValues(typeof(CrossoverAlgorithms));

            this.Controls.Add(grid);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            grid.Algorithms.Add(new AlgorithmInfo
            {
                Crossover = (CrossoverAlgorithms)listCrossover.SelectedValue,
                Initialization = (InitializationAlgorithms)listInitialization.SelectedValue,
                MutationChance = (double)numMutationChance.Value,
                PopulationSize = (int)numN.Value,
                PostGenerationSelection = (PostGenerationSelectionAlgorithms)listPostGenerationSelection.SelectedValue,
                Selection = (SelectionAlgorithms)listSelection.SelectedValue
            });
        }

        private void buttonRunAll_Click(object sender, EventArgs e)
        {
            function = (Func<double, double, double>)engine.Formula(textBoxFunction.Text)
                .Parameter("x1", DataType.FloatingPoint)
                .Parameter("x2", DataType.FloatingPoint)
                .Result(DataType.FloatingPoint)
                .Build();

            var chromosomes = new[]
            {
                new Chromosome { LowerLimit = (int)numMinX.Value, UpperLimit = (int)numMaxX.Value, Name = "X", Scale = (int)numScaleX.Value },
                new Chromosome { LowerLimit = (int)numMinY.Value, UpperLimit = (int)numMaxY.Value, Name = "Y", Scale = (int)numScaleY.Value }
            };

            foreach (var info in grid.Algorithms.Where(a => a.Algorithm == null))
            {
                info.Algorithm = algorithmFactory.Create(info, this.HealthAction, chromosomes);
            }

            var runCount = (int)numRunCount.Value;
            grid.Algorithms.AsParallel().ForAll(a =>
            {
                var i = 0;
                a.Algorithm.Solve(pga => ++i < runCount);
                a.Rating = CalculateRating(a.Algorithm.BestIndividual);
            });

            grid.Refresh();
        }

        private void HealthAction(IIndividual individual)
        {
            individual.Health = function(individual.Genome.First().Value, individual.Genome.Last().Value);
        }

        private double CalculateRating(IIndividual bestIndividual)
        {
            return bestIndividual.Health * 10 / (bestIndividual.Generation * 0.5 + bestIndividual.Id * 0.1);
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            var algorithmInfo = grid.SelectedRows[0].DataBoundItem as AlgorithmInfo;
            var infoForm = new AlgorithmDetailsForm(algorithmInfo.Algorithm);
            infoForm.Show(this);
        }
    }
}
