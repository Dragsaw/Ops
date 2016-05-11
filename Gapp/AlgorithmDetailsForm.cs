using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Ga;
using Ga.Chromosomes;
using Ga.Individuals;
using Ga.Infrastructure;

namespace Gapp
{
    public partial class AlgorithmDetailsForm : Form
    {
        private Color deadColor = Color.Gray;
        private Color invalidColor = Color.Red;
        private Color healthyColor = Color.Green;
        private MarkerStyle deadMarker = MarkerStyle.Cross;
        private MarkerStyle healthyMarker = MarkerStyle.Circle;
        private Series series;
        private LinkedListNode<Iteration> currentIteration;

        public AlgorithmDetailsForm(ParallelGeneticAlgorithm algorithm)
        {
            InitializeComponent();

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;

            var idCol = new DataGridViewTextBoxColumn();
            idCol.Name = "Id";
            idCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns.Add(idCol);

            var xCol = new DataGridViewTextBoxColumn();
            xCol.Name = "X";
            xCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns.Add(xCol);

            var yCol = new DataGridViewTextBoxColumn();
            yCol.Name = "Y";
            yCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns.Add(yCol);

            var healthCol = new DataGridViewTextBoxColumn();
            healthCol.Name = "Health";
            healthCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns.Add(healthCol);

            var binaryCol = new DataGridViewTextBoxColumn();
            binaryCol.Name = "Binary";
            binaryCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns.Add(binaryCol);

            chart.Series.Clear();
            chart.Legends.Clear();
            chart.ChartAreas.Clear();

            var area = chart.ChartAreas.Add("area");
            area.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            area.AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
            area.AxisX.Interval = 1;
            area.AxisY.Interval = 1;
            area.AxisX.Maximum = 15;
            area.AxisY.Maximum = 15;
            area.AxisX.Minimum = -15;
            area.AxisY.Minimum = -15;
            series = chart.Series.Add("series");
            series.ChartType = SeriesChartType.Point;
            series.MarkerSize = 10;
            series.MarkerStyle = healthyMarker;
            series.Color = healthyColor;

            buttonPrevious.Enabled = false;
            currentIteration = algorithm.History.First;
            ShowIterationDetails(currentIteration.Value);
        }

        public void ShowIterationDetails(Iteration iteration)
        {
            series.Points.Clear();
            grid.Rows.Clear();

            foreach (var individual in iteration.InitialPopulation)
            {
                AddIndividual(individual);
            }

            var emptyRow = grid.Rows.Add();
            grid.Rows[emptyRow].DefaultCellStyle.BackColor = Color.Yellow;


            foreach (var individual in iteration.Parents)
            {
                AddIndividual(individual);
            }

            emptyRow = grid.Rows.Add();
            grid.Rows[emptyRow].DefaultCellStyle.BackColor = Color.Orange;

            foreach (var child in iteration.Children)
            {
                AddIndividual(child);
            }

            emptyRow = grid.Rows.Add();
            grid.Rows[emptyRow].DefaultCellStyle.BackColor = Color.Green;

            foreach (var individual in iteration.PostGenerationSelected ?? new List<IIndividual>())
            {
                AddIndividual(individual);
            }
        }

        private void AddIndividual(IIndividual individual)
        {
            var x = individual.Genome.First(i => i.Name == "X").Value;
            var y = individual.Genome.First(i => i.Name == "Y").Value;
            var index = grid.Rows.Add(
                string.Format("{0}.{1}{2}", individual.Generation, individual.Id, individual.IsMutant ? "m" : string.Empty),
                x,
                y,
                individual.Health,
                individual.Bits);
            if (series.Points.Any(i => i.XValue == x && i.YValues[0] == y) == false)
            {
                var id = series.Points.AddXY(x, y);
                var point = series.Points[id];
                point.Label = string.Format("{0}.{1}{2}", individual.Generation, individual.Id, individual.IsMutant ? "m" : string.Empty);
                if (individual.IsHealthy == false)
                {
                    grid.Rows[index].DefaultCellStyle.BackColor = invalidColor;
                    point.MarkerStyle = deadMarker;
                    point.Color = deadColor;
                }
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var plainHistory = currentIteration.Value.InitialPopulation.Concat(currentIteration.Value.Children);
            var row = grid.Rows[e.RowIndex];
            var idValue = row.Cells[0].Value.ToString().Split('.')[1];
            IIndividual individual;
            if (idValue.Contains('m'))
            {
                idValue = idValue.Substring(0, idValue.Length - 1);
                var id = int.Parse(idValue);
                individual = plainHistory.FirstOrDefault(x => x.Id == id && x.IsMutant);
            }
            else
            {
                var id = int.Parse(idValue);
                individual = plainHistory.FirstOrDefault(x => x.Id == id && x.IsMutant == false);
            }

            var individualInfo = new IndividualDetailsForm(individual);
            individualInfo.Show(this);
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
            else
            {
                currentIteration = currentIteration.List.Last;
            }

            buttonPrevious.Enabled = currentIteration.Previous != null;
            buttonLast.Enabled = buttonNext.Enabled = currentIteration.Next != null;

            ShowIterationDetails(currentIteration.Value);
        }
    }
}