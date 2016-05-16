using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Infrastructure;

namespace Ls.LocalSearch
{
    public class BestSampleAlgorithm : ILocalSearchAlgorithm
    {
        private readonly int vectorsCount = 12;
        private readonly double testStep = 0.5;
        private readonly Random random = new Random(DateTime.Now.Millisecond);
        private readonly PointsFactory pointsFactory;

        public BestSampleAlgorithm(PointsFactory pointsFactory)
        {
            this.pointsFactory = pointsFactory;
        }
        public Point Search(Point sourcePoint, Func<double, double, double> func, Point lowerLimit, Point upperLimit)
        {
            double? minVector = null;
            double minZ = sourcePoint.Z;
            for (int i = 0; i < vectorsCount; i++)
            {
                var vector = random.Next(6) + random.NextDouble();
                var dx = testStep * Math.Cos(vector);
                var dy = testStep * Math.Sin(vector);
                var newZ = func(sourcePoint.X + dx, sourcePoint.Y + dy);
                if (newZ < minZ)
                {
                    minZ = newZ;
                    minVector = vector;
                }
            }

            if (minVector.HasValue == false)
            {
                return null;
            }

            var workXStep = testStep * Math.Cos(minVector.Value) * 2;
            var workYStep = testStep * Math.Sin(minVector.Value) * 2;
            var point = pointsFactory.Create(sourcePoint);
            point.X += workXStep;
            point.Y += workYStep;
            point.Z = func(point.X, point.Y);

            return point.Z < sourcePoint.Z ? point : null;
        }
    }
}
