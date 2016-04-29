using Ga.Individuals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gapp
{
    public partial class IndividualDetailsForm : Form
    {
        private readonly IIndividual individual;

        public IndividualDetailsForm(IIndividual individual)
        {
            InitializeComponent();
            this.individual = individual;
            label3.Text = individual.Generation.ToString();
            label4.Text = individual.Id.ToString();

            if (individual.Parents != null && individual.Parents.First != null)
            {
                var p = individual.Parents.First;
                linkLabel1.Text = string.Format("{0}.{1}{2}", p.Generation, p.Id, p.IsMutant ? "m" : string.Empty);
                linkLabel3.Text = p.Bits.ToString();
            }
            else
            {
                linkLabel1.Text = "none";
                linkLabel1.Enabled = false;
                linkLabel3.Text = string.Empty;
            }

            if (individual.Parents != null && individual.Parents.Second != null)
            {
                var p = individual.Parents.Second;
                linkLabel2.Text = string.Format("{0}.{1}{2}", p.Generation, p.Id, p.IsMutant ? "m" : string.Empty);
                linkLabel4.Text = p.Bits.ToString();
            }
            else
            {
                linkLabel2.Text = "none";
                linkLabel2.Enabled = false;
                linkLabel4.Text = string.Empty;
            }

            label9.Text = individual.Bits.ToString();
            label13.Text = string.Format("{0} = {1}", individual.Genome[0].Value, individual.Genome[0].Bits);
            label14.Text = string.Format("{0} = {1}", individual.Genome[1].Value, individual.Genome[1].Bits);

            checkBox1.Checked = individual.IsMutant;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var individualDetails = new IndividualDetailsForm(individual.Parents.First);
            individualDetails.Show(this.Owner);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var individualDetails = new IndividualDetailsForm(individual.Parents.Second);
            individualDetails.Show(this.Owner);
        }
    }
}
