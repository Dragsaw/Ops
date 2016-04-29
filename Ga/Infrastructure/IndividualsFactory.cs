using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Individuals;

namespace Ga.Infrastructure
{
    public class IndividualsFactory
    {
        private int count;

        public IIndividual Create()
        {
            return new Individual { Id = ++count };
        }

        public IIndividual Create(IIndividual other)
        {
            var newIndividual = other.Clone();
            newIndividual.Id = ++count;
            return newIndividual;
        }
    }
}
