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
                CrossoverPoints = new[] { (int)numFirstPoint.Value, (int)numSecondPoint.Value },
                Initialization = (InitializationAlgorithms)listInitialization.SelectedValue,
                MutationChance = (double)numMutationChance.Value,
                PopulationSize = (int)numN.Value,
                PostGenerationSelection = (PostGenerationSelectionAlgorithms)listPostGenerationSelection.SelectedValue,
                Selection = (SelectionAlgorithms)listSelection.SelectedValue
            });
        }
    }
}
