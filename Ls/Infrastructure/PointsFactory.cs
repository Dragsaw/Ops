using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ls.Infrastructure
{
    public class PointsFactory
    {
        private int count;

        public Point Create()
        {
            return new Point { Id = ++count };
        }

        public Point Create(Point other)
        {
            var newPoint = Create();
            newPoint.X = other.X;
            newPoint.Y = other.Y;
            newPoint.Z = other.Z;
            return newPoint;
        }
    }
}
