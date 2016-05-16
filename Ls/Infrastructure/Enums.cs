using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gared;
using Ls.LocalSearch;

namespace Ls.Infrastructure
{
    public enum RunOptions { AutomaticStop, Once }

    public enum LocalSearchAlgorithms
    {
        [Algorithm(typeof(GaussAlgorithm))]
        Gauss
    }

    public enum SelectionAlgorithms
    {
        //[Algorithm(typeof(RandomSelectionAlgorithm))]
        //Random,
        [Algorithm(typeof(Ls.Selection.BestNSelectionAlgorithm))]
        BestN
    }

    public enum InitializationAlgorithms
    {
        [Algorithm(typeof(Ls.Initialization.RandomInitializationAlgorithm))]
        Random,
        //[Algorithm(typeof(GridInitializationAlgorithm))]
        //Grid
    }
}
