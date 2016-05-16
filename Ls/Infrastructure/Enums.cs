using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gared;
using Ls.LocalSearch;
using Ls.Selection;
using Ls.Initialization;

namespace Ls.Infrastructure
{
    public enum RunOptions { AutomaticStop, Once }

    public enum LocalSearchAlgorithms
    {
        [Algorithm(typeof(GaussAlgorithm))]
        Gauss,
        [Algorithm(typeof(BestSampleAlgorithm))]
        BestSample
    }

    public enum SelectionAlgorithms
    {
        [Algorithm(typeof(RandomSelectionAlgorithm))]
        Random,
        [Algorithm(typeof(BestNSelectionAlgorithm))]
        BestN
    }

    public enum InitializationAlgorithms
    {
        [Algorithm(typeof(RandomInitializationAlgorithm))]
        Random,
        //[Algorithm(typeof(GridInitializationAlgorithm))]
        //Grid
    }
}
