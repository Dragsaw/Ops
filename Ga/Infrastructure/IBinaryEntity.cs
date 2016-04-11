using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Infrastructure
{
    /// <summary>Dclares properties and methods of a binary entity.</summary>
    public interface IBinaryEntity
    {
        /// <summary>Gets the length of binary representation.</summary>
        int BinaryLength { get; }
        /// <summary>Gets the binary representation.</summary>
        Binary Bits { get; }
        /// <summary>
        /// Updates the value from binary representation of the chromosome.
        /// </summary>
        /// <param name="b">Binary representation of the chromosome</param>
        void Update(Binary b);
    }
}
