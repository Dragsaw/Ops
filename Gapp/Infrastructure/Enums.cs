using Ga.Crossover;
using Ga.Initialization;
using Ga.Selection;
using Ga.Selection.PostGeneration;

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
        Grid,
        User
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
}