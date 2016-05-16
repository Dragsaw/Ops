using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Crossover;
using Ga.Initialization;
using Ga.Selection;
using Ga.Selection.PostGeneration;
using Gared;

namespace Ga.Infrastructure
{
    public enum SelectionAlgorithms
    {
        [Algorithm(typeof(RandomSelectionAlgorithm))]
        Random,
        [Algorithm(typeof(BestNSelectionAlgorithm))]
        BestN,
        [Algorithm(typeof(TournamentSelectionAlgorithm))]
        Tournament
    }

    public enum InitializationAlgorithms
    {
        [Algorithm(typeof(RandomInitializationAlgorithm))]
        Random,
        [Algorithm(typeof(GridInitializationAlgorithm))]
        Grid
    }

    public enum CrossoverAlgorithms
    {
        [Algorithm(typeof(SinglePointCrossoverAlgorithm))]
        SinglePoint,
        [Algorithm(typeof(DoublePointCrossoverAlgorithm))]
        DoublePoint
    }

    public enum PostGenerationSelectionAlgorithms
    {
        [Algorithm(typeof(PostGenerationSelectAllAlgorithm))]
        All,
        [Algorithm(typeof(PostGenerationSelectBestFromAll))]
        BestFromAll,
        [Algorithm(typeof(PostGenerationSelectBestFromChildren))]
        BestFromChildren
    }

    public enum Mutate
    {
        Children,
        Parents,
        ParentsAndChildren
    }
}
