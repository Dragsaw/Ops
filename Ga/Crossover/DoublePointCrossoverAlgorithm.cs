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
        private readonly int firstPoint;
        private readonly int secondPoint;

        public DoublePointCrossoverAlgorithm(params int[] points)
        {
            this.firstPoint = points[0];
            this.secondPoint = points[1];
        }

        public IEnumerable<IIndividual> Crossover(IPare pare, int generation)
        {
            var child1 = pare.First.Clone();
            var child2 = pare.First.Clone();
            var str1 = pare.First.Bits.ToString();
            var str2 = pare.Second.Bits.ToString();
            var child1String = str1.Substring(0, firstPoint) +
                str2.Substring(firstPoint, secondPoint - firstPoint) +
                str1.Substring(secondPoint);
            var child2String = str2.Substring(0, firstPoint) +
                str1.Substring(firstPoint, secondPoint - firstPoint) +
                str2.Substring(secondPoint);
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
