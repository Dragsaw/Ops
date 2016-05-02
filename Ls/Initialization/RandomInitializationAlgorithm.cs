using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Infrastructure;

namespace Ls.Initialization
{
    public class RandomInitializationAlgorithm : IInitializationAlgorithm
    {
        private readonly PointsFactory pointsFactory;
        private readonly Random random = new Random(DateTime.Now.Millisecond);

        public RandomInitializationAlgorithm(PointsFactory pointsFactory)
        {
            this.pointsFactory = pointsFactory;
        }

        public IEnumerable<Point> Initialize(int count, Point lowerBound, Point upperBound)
        {
            var result = new Point[count];
            for (int i = 0; i < count; i++)
            {
                var newPoint = pointsFactory.Create();
                newPoint.X = random.Next((int)lowerBound.X, (int)upperBound.X) + random.NextDouble();
                newPoint.Y = random.Next((int)lowerBound.Y, (int)upperBound.Y) + random.NextDouble();
                result[i] = newPoint;
            }

            return result;
        }
    }
}
