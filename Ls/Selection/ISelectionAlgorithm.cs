using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Infrastructure;

namespace Ls.Selection
{
    public interface ISelectionAlgorithm
    {
        IEnumerable<Point> Select(int count, IEnumerable<Point> points);
    }
}
