using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ga.Forms
{
    [Serializable]
    public class TwoParamsAlgorithmParams
    {
        public double XUpper { get; set; }

        public double XLower { get; set; }

        public double YUpper { get; set; }

        public double YLower { get; set; }

        public int XScale { get; set; }

        public int YScale { get; set; }

        public int InitSize { get; set; }

        public int PopulationSize { get; set; }

        public double MutationChance { get; set; }
    }
}
