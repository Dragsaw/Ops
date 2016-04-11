using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ga.Forms
{
    public class IndividualsDataAdapter
    {
        private DataGridView grid;

        public IndividualsDataAdapter(DataGridView grid)
        {
            this.grid = grid;
            this.AddColumns();
        }

        public void Add(IndividualViewModel individual)
        {
            grid.Rows.Insert(0, this.GetFulldId(individual), individual.X, individual.Y, individual.Health, individual.Binary);
            if (individual.IsHealthy == false)
            {
                grid.Rows[0].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        public void AddPopulation(IEnumerable<IndividualViewModel> individuals)
        {
            foreach (var ind in individuals.OrderBy(x => x.Health).ThenByDescending(x => x.Id))
            {
                this.Add(ind);
            }

            grid.Rows.Insert(individuals.Count());
            grid.Rows[individuals.Count()].DefaultCellStyle.BackColor = Color.Black;
        }

        private string GetFulldId(IndividualViewModel model)
        {
            return string.Format("{0}.{1}{2}", model.Generation, model.Id, model.IsMutant ? "m" : string.Empty);
        }

        private void AddColumns()
        {
            var idCol = grid.Columns.Add("Id", "Id");
            grid.Columns[idCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[idCol].FillWeight = 0.2f;
            var xCol = grid.Columns.Add("X", "X");
            grid.Columns[xCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[xCol].FillWeight = 0.1f;
            var yCol = grid.Columns.Add("Y", "Y");
            grid.Columns[yCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[yCol].FillWeight = 0.1f;
            var healthCol = grid.Columns.Add("Health", "Health");
            grid.Columns[healthCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[healthCol].FillWeight = 0.1f;
            var binCol = grid.Columns.Add("Binary", "Binary");
            grid.Columns[binCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid.Columns[binCol].FillWeight = 0.5f;
        }

        public bool GetIndividualId(int rowIndex, out int individualId)
        {
            bool isMutant = false;
            var row = grid.Rows[rowIndex];
            var stringId = row.Cells["Id"].Value.ToString().Split('.').Last();
            if (stringId.Contains('m'))
            {
                isMutant = true;
                stringId = stringId.Replace("m", string.Empty);
            }
            individualId = int.Parse(stringId);
            return isMutant;
        }
    }
}
