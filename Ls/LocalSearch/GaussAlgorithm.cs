using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Infrastructure;

namespace Ls.LocalSearch
{
    public class GaussAlgorithm : ILocalSearchAlgorithm
    {
        private readonly PointsFactory pointsFactory;

        public GaussAlgorithm(PointsFactory pointsFactory)
        {
            this.pointsFactory = pointsFactory;
        }

        public bool Search(IList<Point> points, Func<double, double, double> func, Point lowerLimit, Point upperLimit)
        {
            var step = 0.5;
            var bestPoint = points.OrderByDescending(point => point.Z).First();
            var newPoint = pointsFactory.Create(bestPoint);
            for (double i = lowerLimit.X; i < upperLimit.X; i += step)
            {
                var newZ = func(i, newPoint.Y);
                if (newZ < newPoint.Z)
                {
                    newPoint.Z = newZ;
                    newPoint.X = i;
                }
            }

            for (double i = lowerLimit.Y; i < upperLimit.Y; i += step)
            {
                var newZ = func(newPoint.X, i);
                if (newZ < newPoint.Z)
                {
                    newPoint.Z = newZ;
                    newPoint.Y = i;
                }
            }

            points.Add(newPoint);

            return bestPoint.X == newPoint.X && bestPoint.Y == newPoint.Y;
        }
    }
}
