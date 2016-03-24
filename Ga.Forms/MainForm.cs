using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ga.Forms
{
    public partial class MainForm : Form
    {
        private TwoParamsAlgotirhm algorithm;

        public MainForm()
        {
            InitializeComponent();
            algorithm = new TwoParamsAlgotirhm(10, 0, 10, 0, 0, 0);
            dataGridView1.DataSource = algorithm.Population.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            algorithm.Run();
            dataGridView1.DataSource = algorithm.Population.ToArray();
        }
    }
}
