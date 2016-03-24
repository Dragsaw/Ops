using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Infrastructure
{
    public interface IBinaryEntity
    {
        int BinaryLength { get; }
        Binary Bits { get; }
        void Update(Binary b);
    }
}
