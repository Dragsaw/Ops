using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Infrastructure;

namespace Ga.Chromosomes
{
    public class Chromosome : IChromosome
    {
        private double value;

        public int BinaryLength { get { return Bits.Value.Count(); } }

        public Binary Bits { get { return new Binary(Value, Scale, UpperLimit, LowerLimit); } }

        public bool IsValid { get { return Value >= LowerLimit && Value <= UpperLimit; } }

        public double LowerLimit { get; set; }

        public string Name { get; set; }

        public int Scale { get; set; }

        public double UpperLimit { get; set; }

        public double Value
        {
            get { return value; }
            set { this.value = Math.Round(value, Scale); }
        }

        public void Update(Binary b)
        {
            var newBinary = new Binary(b.ToString(), Scale);
            value = newBinary.NumericValue;
        }

        public IChromosome Clone()
        {
            return new Chromosome
            {
                LowerLimit = this.LowerLimit,
                Name = this.Name,
                Scale = this.Scale,
                UpperLimit = this.UpperLimit,
                Value = this.Value
            };
        }
    }
}
