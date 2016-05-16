﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;

namespace Ga.Selection.PostGeneration
{
    public class PostGenerationSelectAllAlgorithm : IPostGenerationSelectionAlgorithm
    {
        public IEnumerable<IIndividual> Select(IEnumerable<IIndividual> children, int? count)
        {
            var result =  children
                .Aggregate(new List<IIndividual>(), (list, child) =>
                {
                    if (child.IsHealthy)
                    {
                        list.Add(child);
                    }

                    list.Add(child.Parents.First);
                    if (child.IsMutant == false)
                    {
                        list.Add(child.Parents.Second);
                    }

                    return list;
                });
            return result.Where(x => x != null).Take(count ?? result.Count);
        }
    }
}
