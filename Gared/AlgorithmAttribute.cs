using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gared
{
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public class AlgorithmAttribute : Attribute
    {
        public Type AlgorithmType { get; set; }

        public AlgorithmAttribute(Type algorithmType)
        {
            this.AlgorithmType = algorithmType;
        }
    }
}
