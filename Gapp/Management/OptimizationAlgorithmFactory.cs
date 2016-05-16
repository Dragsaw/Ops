using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;
using Ga.Infrastructure;
using Gapp.Infrastructure;
using Ls;
using Ls.Infrastructure;
using Ls.Initialization;
using Ls.LocalSearch;
using Ls.Selection;

namespace Gapp.Management
{
    public class OptimizationAlgorithmFactory
    {
        public OptimizationAlgorithm Create(IIndividual individual, Point upperLimit, Point lowerLimit, Func<double, double, double> func)
        {
            var initialization = (Ls.Infrastructure.InitializationAlgorithms)individual.Genome.First(x => x.Name == "Initialization").Value;
            var selection = (Ls.Infrastructure.SelectionAlgorithms)individual.Genome.First(x => x.Name == "Selection").Value;
            var search = (LocalSearchAlgorithms)individual.Genome.First(x => x.Name == "Search").Value;
            var initialCount = (int)individual.Genome.First(x => x.Name == "N").Value;
            var selectedCount = (int)individual.Genome.First(x => x.Name == "n").Value;
            var runCondition = (RunOptions)individual.Genome.First(x => x.Name == "Run").Value;

            var pointsFactory = new PointsFactory(); ;
            var initializationAlgorithm = Activator.CreateInstance(initialization.GetAlgorithmType(), pointsFactory) as IInitializationAlgorithm;
            var selectionAlgorithm = Activator.CreateInstance(selection.GetAlgorithmType()) as ISelectionAlgorithm;
            var searchAlgorithm = Activator.CreateInstance(search.GetAlgorithmType(), pointsFactory) as ILocalSearchAlgorithm;

            return new OptimizationAlgorithm(initializationAlgorithm, selectionAlgorithm, searchAlgorithm, upperLimit, lowerLimit, initialCount, selectedCount, func, runCondition);
        }
    }
}
