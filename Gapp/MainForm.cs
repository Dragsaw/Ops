using Ga.Chromosomes;
using Ga.Individuals;
using Gapp.Infrastructure;
using Gapp.Management;
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
        AlgorithmsGridView grid = new AlgorithmsGridView();
        AlgorithmFactory algorithmFactory = new AlgorithmFactory();

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
            var algorithmInfos = new List<AlgorithmInfo>();
            foreach (DataGridViewRow row in grid.Rows)
            {
                algorithmInfos.Add(row.DataBoundItem as AlgorithmInfo);
            }


            var chromosomes = new[]
            {
                new Chromosome { LowerLimit = (int)numMinX.Value, UpperLimit = (int)numMaxX.Value, Name = "X", Scale = (int)numScaleX.Value },
                new Chromosome { LowerLimit = (int)numMinY.Value, UpperLimit = (int)numMaxY.Value, Name = "Y", Scale = (int)numScaleY.Value }
            };
            var algorithms = algorithmInfos
                .Select(x =>
                {
                    x.Algorithm = algorithmFactory.Create(x, this.HealthAction, chromosomes);
                    return x.Algorithm;
                })
                .ToArray();
            algorithms
                .AsParallel()
                .ForAll(x => x.Solve(a => a.Population.Max(i => i.Generation) < 20));
            for (int i = 0; i < algorithms.Length; i++)
            {
                var info = grid.Rows[i].DataBoundItem as AlgorithmInfo;
                var best = algorithms[i].Population.OrderByDescending(x => x.Health).ThenBy(x => x.Id).First(x => x.IsHealthy);
                info.Rating = best.Health * 10 / (best.Generation * 0.5 + best.Id * 0.1);
            }
            grid.Refresh();
        }

        private void HealthAction(IIndividual individual)
        {
            individual.Health = individual.Genome.First().Value + individual.Genome.Last().Value;
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            var algorithmInfo = grid.SelectedRows[0].DataBoundItem as AlgorithmInfo;
            var infoForm = new AlgorithmDetailsForm(algorithmInfo.Algorithm);
            infoForm.Show(this);
        }
    }
}
