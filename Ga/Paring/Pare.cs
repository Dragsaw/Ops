using System;
using Ga.Individuals;

namespace Ga.Paring
{
    public class Pare : IPare
    {
        public IIndividual First { get; set; }

        public IIndividual Second { get; set; }
    }
}