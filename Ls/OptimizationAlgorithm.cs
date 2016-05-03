using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ls.Infrastructure;
using Ls.Initialization;
using Ls.LocalSearch;
using Ls.Selection;

namespace Ls
{
    public class OptimizationAlgorithm
    {
        private readonly IInitializationAlgorithm initializationAlgorithm;
        private readonly ISelectionAlgorithm selectionAlgorithm;
        private readonly ILocalSearchAlgorithm localSearchAlgorithm;
        private readonly Point upperLimit;
        private readonly Point loweLimit;
        private readonly int initialCount;
        private readonly int selectedCount;
        private readonly Func<double, double, double> func;
        private readonly RunOptions runUntil;

        public IEnumerable<Point> Points { get; set; }

        public OptimizationAlgorithm(IInitializationAlgorithm initializationAlgorithm,
            ISelectionAlgorithm selectionAlgorithm,
            ILocalSearchAlgorithm localSearchAlgorithm,
            Point upperLimit,
            Point loweLimit,
            int initialCount,
            int selectedCount,
            Func<double, double, double> func,
            RunOptions runUntil)
        {
            this.initializationAlgorithm = initializationAlgorithm;
            this.selectionAlgorithm = selectionAlgorithm;
            this.localSearchAlgorithm = localSearchAlgorithm;
            this.upperLimit = upperLimit;
            this.loweLimit = loweLimit;
            this.initialCount = initialCount;
            this.selectedCount = selectedCount;
            this.func = func;
            this.runUntil = runUntil;
        }

        public void Run()
        {
            var points = initializationAlgorithm.Initialize(initialCount, loweLimit, upperLimit);
            foreach (var point in points)
            {
                point.Z = func(point.X, point.Y);
            }

            var selected = selectionAlgorithm.Select(selectedCount, points).ToList();
            foreach (var point in selected)
            {
                var sourcePoint = point;
                do
                {
                    sourcePoint.Next = localSearchAlgorithm.Search(sourcePoint, func, loweLimit, upperLimit);
                    sourcePoint = sourcePoint.Next;
                } while (sourcePoint != null && runUntil == RunOptions.AutomaticStop);
            }

            Points = selected;
        }
    }
}
