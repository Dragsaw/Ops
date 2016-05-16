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
using Ls;

namespace Gapp
{
    public partial class OptimizationForm : Form
    {
        public OptimizationForm(OptimizationAlgorithm optimization)
        {
            InitializeComponent();

            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.Legends.Clear();

            var area = chart.ChartAreas.Add("area");
            area.AxisX.Interval = 1;
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 10;
            area.AxisY.Interval = 1;
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 10;

            var pointsList = optimization.Points.ToList();
            for (int i = 0; i < pointsList.Count; i++)
            {
                var point = pointsList[i];
                var pointSeries = chart.Series.Add("points" + i);
                pointSeries.ChartType = SeriesChartType.Point;
                pointSeries.MarkerStyle = MarkerStyle.Circle; ;
                var lineSeries = chart.Series.Add("lines" + i);
                lineSeries.ChartType = SeriesChartType.Line;
                var startPoints = chart.Series.Add("start" + i);
                startPoints.ChartType = SeriesChartType.Point;
                startPoints.MarkerSize = 10;
                startPoints.MarkerStyle = MarkerStyle.Cross;

                startPoints.Points.AddXY(Math.Round(point.X, 3), Math.Round(point.Y, 3));
                lineSeries.Points.AddXY(Math.Round(point.X, 3), Math.Round(point.Y, 3));
                var currentPoint = point;
                pointSeries.MarkerSize = 5;
                while (currentPoint.Next != null)
                {
                    currentPoint = currentPoint.Next;
                    pointSeries.Points.AddXY(Math.Round(currentPoint.X, 3), Math.Round(currentPoint.Y, 3));
                    lineSeries.Points.AddXY(Math.Round(currentPoint.X, 3), Math.Round(currentPoint.Y, 3));
                }
            }
        }
    }
}
