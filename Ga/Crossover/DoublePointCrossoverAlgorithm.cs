using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Paring;
using Ga.Infrastructure;

namespace Ga.Crossover
{
    public class DoublePointCrossoverAlgorithm : ICrossoverAlgorithm
    {
        public IEnumerable<IIndividual> Crossover(IPare pare, int generation)
        {
            int point1 = pare.First.BinaryLength / 3;
            int point2 = pare.First.BinaryLength * 2 / 3;
            var child1 = pare.First.Clone();
            var child2 = pare.First.Clone();
            var str1 = pare.First.Bits.ToString();
            var str2 = pare.Second.Bits.ToString();
            var child1String = str1.Substring(0, point1) +
                str2.Substring(point1, point2 - point1) +
                str1.Substring(point2);
            var child2String = str2.Substring(0, point1) +
                str1.Substring(point1, point2 - point1) +
                str2.Substring(point2);
            child1.Update(new Binary(child1String));
            child1.Generation = generation;
            child1.Parents = new Pare { First = pare.First, Second = pare.Second };
            child2.Update(new Binary(child2String));
            child2.Generation = generation;
            child2.Parents = new Pare { First = pare.Second, Second = pare.First };
            return new IIndividual[] { child1, child2 };
        }
    }
}
