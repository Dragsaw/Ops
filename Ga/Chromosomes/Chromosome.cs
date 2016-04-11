using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ga.Infrastructure;

namespace Ga.Chromosomes
{
    /// <summary>Represents a chromosome.</summary>
    public class Chromosome : IChromosome
    {
        private double value;

        /// <summary>Gets the length of binary representation.</summary>
        public int BinaryLength { get { return new Binary(UpperLimit, Scale, UpperLimit, LowerLimit).Value.Count(); } }

        /// <summary>Gets the binary representation.</summary>
        public Binary Bits { get { return new Binary(Value, Scale, UpperLimit, LowerLimit); } }

        /// <summary>Indicates if chromosome contains a valid value.</summary>
        public bool IsValid { get { return Value >= LowerLimit && Value <= UpperLimit; } }

        /// <summary>Gets or sets the lower limit of the value.</summary>
        public double LowerLimit { get; set; }

        /// <summary>Gets or sets the name of the chromosome.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the number of decimal places of the value.</summary>
        public int Scale { get; set; }

        /// <summary>Gets or sets the upper limit of the value.</summary>
        public double UpperLimit { get; set; }

        /// <summary>Gets or sets the value.</summary>
        public double Value
        {
            get { return value; }
            set { this.value = Math.Round(value, Scale); }
        }

        /// <summary>
        /// Updates the value from binary representation of the chromosome.
        /// </summary>
        /// <param name="b">Binary representation of the chromosome</param>
        public void Update(Binary b)
        {
            var newBinary = new Binary(b.ToString(), Scale);
            value = newBinary.NumericValue;
        }

        /// <summary>
        /// Creates a deep copy of the object.
        /// </summary>
        /// <returns>Copy of the object.</returns>
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
