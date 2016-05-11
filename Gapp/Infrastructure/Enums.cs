using Ga.Crossover;
using Ga.Initialization;
using Ga.Selection;
using Ga.Selection.PostGeneration;
using Ls.LocalSearch;

namespace Gapp.Infrastructure
{
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

    public enum LsLocalSearchAlgorithms
    {
        [Algorithm(typeof(GaussAlgorithm))]
        Gauss
    }

    public enum LsSelectionAlgorithms
    {
        //[Algorithm(typeof(RandomSelectionAlgorithm))]
        //Random,
        [Algorithm(typeof(Ls.Selection.BestNSelectionAlgorithm))]
        BestN
    }

    public enum LsInitializationAlgorithms
    {
        [Algorithm(typeof(Ls.Initialization.RandomInitializationAlgorithm))]
        Random,
        //[Algorithm(typeof(GridInitializationAlgorithm))]
        //Grid
    }
}