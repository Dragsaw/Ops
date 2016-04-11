using Ga.Individuals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ga.Forms
{
    public partial class MainForm : Form
    {
        private TwoParamsAlgotirhm algorithm;
        private IndividualsDataAdapter dataAdapter;
        private IndividualsGraphAdapter graphAdapter;
        private AlgorithmParamsProvider paramsProvider;
        private BindingList<IndividualViewModel> gridDataSource = new BindingList<IndividualViewModel>();

        public MainForm()
        {
            InitializeComponent();
            dataAdapter = new IndividualsDataAdapter(individualsGrid);
            graphAdapter = new IndividualsGraphAdapter(pointsChart);
            paramsProvider = new AlgorithmParamsProvider();
            if (paramsProvider.TryRestore())
            {
                PopulateFields(paramsProvider.Params);
            }
        }

        private void PopulateFields(TwoParamsAlgorithmParams param)
        {
            maxX.Value = (decimal)param.XUpper;
            minX.Value = (decimal)param.XLower;
            maxY.Value = (decimal)param.YUpper;
            minY.Value = (decimal)param.YLower;
            scaleX.Value = param.XScale;
            scaleY.Value = param.YScale;
            initSize.Value = param.InitSize;
            populationSize.Value = param.PopulationSize;
            mutationChance.Value = (decimal)param.MutationChance;
        }

        private void AddData()
        {
            dataAdapter.AddPopulation(algorithm.Population);
            graphAdapter.AddRange(algorithm.Population);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (algorithm == null)
            {
                ToggleControls(false);
                InitializeAlgorithm();
                AddData();
            }

            algorithm.Run();
            AddData();
        }

        private void ToggleControls(bool enabled)
        {
            foreach (var c in groupBox1.Controls)
            {
                if (c is Button == false)
                {
                    (c as Control).Enabled = enabled;
                }
            }
        }

        private void InitializeAlgorithm()
        {
            algorithm = new TwoParamsAlgotirhm(
            (double)maxX.Value,
            (double)minX.Value,
            (double)maxY.Value,
            (double)minY.Value,
            (int)scaleX.Value,
            (int)scaleY.Value,
            (int)initSize.Value,
            (int)populationSize.Value,
            (double)mutationChance.Value);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            paramsProvider.Params.XUpper = (double)maxX.Value;
            paramsProvider.Params.XLower = (double)minX.Value;
            paramsProvider.Params.YUpper = (double)maxY.Value;
            paramsProvider.Params.YLower = (double)minY.Value;
            paramsProvider.Params.XScale = (int)scaleX.Value;
            paramsProvider.Params.YScale = (int)scaleY.Value;
            paramsProvider.Params.InitSize = (int)initSize.Value;
            paramsProvider.Params.PopulationSize = (int)populationSize.Value;
            paramsProvider.Params.MutationChance = (double)mutationChance.Value;
            paramsProvider.Save();
            MessageBox.Show("Saved!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < runsCount.Value; i++)
            {
                if (algorithm == null)
                {
                    ToggleControls(false);
                    InitializeAlgorithm();
                    AddData();
                    i++;
                }

                algorithm.Run();
                AddData();
            }
        }

        private void individualsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int individualId;
            var isMutant = dataAdapter.GetIndividualId(e.RowIndex, out individualId);
            var individual = algorithm.History.First(x => x.Id == individualId && x.IsMutant == isMutant);
            using (var individualDetail = new IndividualDetailsForm(individual))
            {
                individualDetail.ShowDialog(this);
            }
        }
    }
}
