using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ga.Forms
{
    public class IndividualsGraphAdapter
    {
        private Chart graph;
        private Series series;
        private Color deadColor = Color.Gray;
        private Color invalidColor = Color.Red;
        private Color healthyColor = Color.Green;
        private MarkerStyle deadMarker = MarkerStyle.Cross;
        private MarkerStyle healthyMarker = MarkerStyle.Circle;

        public ChartArea Area { get; set; }

        public IndividualsGraphAdapter(Chart graph)
        {
            this.graph = graph;
            this.graph.ChartAreas.Clear();
            this.graph.Series.Clear();
            this.graph.Legends.Clear();
            Area = this.graph.ChartAreas.Add("graph");
            Area.AxisX.Minimum = -20;
            Area.AxisX.Maximum = 20;
            Area.AxisX.Interval = 2;
            Area.AxisY.Minimum = -20;
            Area.AxisY.Maximum = 20;
            Area.AxisY.Interval = 2;
            series = this.graph.Series.Add("individuals");
            series.ChartType = SeriesChartType.Point;
            series.MarkerSize = 10;
        }

        public void AddRange(IEnumerable<IndividualViewModel> individuals)
        {
            foreach (var p in series.Points)
            {
                p.MarkerStyle = deadMarker;
                p.Color = deadColor;
            }

            foreach (var item in individuals)
            {
                var point = series.Points.FirstOrDefault(x => x.XValue == item.X && x.YValues[0] == item.Y);
                if (point == null)
                {
                    var pointId = series.Points.AddXY(item.X, item.Y);
                    point = series.Points[pointId];
                }

                if (item.IsHealthy)
                {
                    point.MarkerStyle = healthyMarker;
                    point.Color = healthyColor;
                }
                else
                {
                    point.MarkerStyle = deadMarker;
                    point.Color = invalidColor;
                }
            }
        }
    }
}
