using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Infrastructure;

namespace Ls.Initialization
{
    public interface IInitializationAlgorithm
    {
        IEnumerable<Point> Initialize(int count, Point lowerBound, Point upperBound);
    }
}
