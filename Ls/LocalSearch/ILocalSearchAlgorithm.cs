using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Infrastructure;

namespace Ls.LocalSearch
{
    public interface ILocalSearchAlgorithm
    {
        Point Search(Point points, Func<double, double, double> func, Point lowerLimit, Point upperLimit);
    }
}
