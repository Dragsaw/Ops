using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Infrastructure;

namespace Ls.Selection
{
    public class BestNSelectionAlgorithm : ISelectionAlgorithm
    {
        public IEnumerable<Point> Select(int count, IEnumerable<Point> points)
        {
            return points.OrderByDescending(point => point.Z).Take(count);
        }
    }
}
