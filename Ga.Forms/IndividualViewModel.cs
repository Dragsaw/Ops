using Ga.Individuals;
using System.Linq;

namespace Ga.Forms
{
    public class IndividualViewModel
    {
        private IIndividual x;

        public string Id { get { return x.Label; } }

        public double X { get { return x.Genome.First(x => x.Name == "X").Value; } }

        public double Y { get { return x.Genome.First(x => x.Name == "Y").Value; } }

        public double Health { get { return x.Health; } }

        public string Binary { get { return x.Bits.ToString(); } }

        public IndividualViewModel(IIndividual x)
        {
            this.x = x;
        }
    }
}