using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Chromosomes;
using Ga.Infrastructure;

namespace Ga.Individuals
{
    public class Individual : IIndividual
    {
        public Individual()
        {
            Genome = new List<IChromosome>();
            Count++;
            Id = Count;
        }

        public Binary Bits
        {
            get
            {
                return Genome.Aggregate(new Binary(), (agg, c) => agg.Concat(c.Bits));
            }
        }

        public static int Count { get; set; }

        public int Generation { get; set; }

        public IList<IChromosome> Genome { get; set; }

        public double Health { get; set; }

        public int Id { get; set; }

        public string Label { get { return string.Format("{0}.{1}", Generation, Id); } }

        public bool IsHealthy
        {
            get
            {
                return Genome.All(x => x.IsValid);
            }
        }

        public int BinaryLength { get { return Genome.Sum(x => x.BinaryLength); } }

        public void Update(Binary b)
        {
            var currentPosition = 0;
            foreach (var c in Genome)
            {
                c.Update(b.Subbinary(currentPosition, c.BinaryLength));
                currentPosition += c.BinaryLength;
            }
        }

        public IIndividual Clone()
        {
            return new Individual
            {
                Generation = this.Generation,
                Genome = this.Genome.Select(x => x.Clone()).ToList(),
                Health = this.Health,
                Id = Count
            };
        }
    }
}
