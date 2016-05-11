using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ga.Individuals;
using Ga.Infrastructure;

namespace Gapp.Infrastructure
{
    public static class ExtentionMethods
    {
        public static Type GetAlgorithmType(this Enum value)
        {
            var algorithmAttribute = value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(AlgorithmAttribute), false)
                .FirstOrDefault() as AlgorithmAttribute;

            if (algorithmAttribute == null)
            {
                return null;
            }

            return algorithmAttribute.AlgorithmType;
        }

        public static void ShowIteration(this DataGridView grid, Iteration iteration, Action<IIndividual> addIndividual)
        {
            grid.Rows.Clear();

            foreach (var individual in iteration.InitialPopulation)
            {
                addIndividual(individual);
            }

            var emptyRow = grid.Rows.Add();
            grid.Rows[emptyRow].DefaultCellStyle.BackColor = Color.Yellow;


            foreach (var individual in iteration.Parents)
            {
                addIndividual(individual);
            }

            emptyRow = grid.Rows.Add();
            grid.Rows[emptyRow].DefaultCellStyle.BackColor = Color.Orange;

            foreach (var child in iteration.Children)
            {
                addIndividual(child);
            }

            emptyRow = grid.Rows.Add();
            grid.Rows[emptyRow].DefaultCellStyle.BackColor = Color.Green;

            foreach (var individual in iteration.PostGenerationSelected ?? new List<IIndividual>())
            {
                addIndividual(individual);
            }
        }
    }
}
