using Gapp.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gapp
{
    public class AlgorithmsGridView : DataGridView
    {
        public BindingList<AlgorithmInfo> Algorithms { get; set; }

        public AlgorithmsGridView()
        {
            this.Algorithms = new BindingList<AlgorithmInfo>();
            this.MinimumSize = new Size(785, 172);
            this.Location = new Point(0, 190);
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = true;
            this.ScrollBars = ScrollBars.Vertical;
            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            this.AutoGenerateColumns = false;
            this.DataSource = this.Algorithms;

            var populationSizeCol = new DataGridViewTextBoxColumn();
            populationSizeCol.DataPropertyName = "PopulationSize";
            populationSizeCol.Name = "Population Size";
            populationSizeCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            populationSizeCol.FillWeight = 0.1f;
            this.Columns.Add(populationSizeCol);

            var selectionCol = new DataGridViewTextBoxColumn();
            selectionCol.DataPropertyName = "SelectionName";
            selectionCol.Name = "Selection";
            selectionCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            selectionCol.FillWeight = 0.12f;
            this.Columns.Add(selectionCol);

            var initializationCol = new DataGridViewTextBoxColumn();
            initializationCol.DataPropertyName = "InitializationName";
            initializationCol.Name = "Initialization";
            initializationCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            initializationCol.FillWeight = 0.12f;
            this.Columns.Add(initializationCol);

            var crossoverCol = new DataGridViewTextBoxColumn();
            crossoverCol.DataPropertyName = "CrossoverName";
            crossoverCol.Name = "Crossover";
            crossoverCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            crossoverCol.FillWeight = 0.14f;
            this.Columns.Add(crossoverCol);

            var mutationCol = new DataGridViewTextBoxColumn();
            mutationCol.DataPropertyName = "MutationChance";
            mutationCol.Name = "Mutation Chance";
            mutationCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            mutationCol.FillWeight = 0.12f;
            this.Columns.Add(mutationCol);

            var postGenerationSelectionCol = new DataGridViewTextBoxColumn();
            postGenerationSelectionCol.DataPropertyName = "PostGenerationSelectionName";
            postGenerationSelectionCol.Name = "Post Generation Selection";
            postGenerationSelectionCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            postGenerationSelectionCol.FillWeight = 0.14f;
            this.Columns.Add(postGenerationSelectionCol);

            var ratingCol = new DataGridViewTextBoxColumn();
            ratingCol.DataPropertyName = "Rating";
            ratingCol.Name = "Rating";
            ratingCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ratingCol.FillWeight = 0.12f;
            this.Columns.Add(ratingCol);
        }
    }
}
