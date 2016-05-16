using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Infrastructure;

namespace Ls.Selection
{
    public class RandomSelectionAlgorithm : ISelectionAlgorithm
    {
        private readonly Random random = new Random(DateTime.Now.Millisecond);

        public IEnumerable<Point> Select(int count, IEnumerable<Point> points)
        {
            int maxValue = points.Count();
            for (int i = 0; i < count; i++)
            {
                yield return points.ElementAt(random.Next(maxValue));
            }
        }
    }
}
