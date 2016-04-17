using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gapp.Infrastructure
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class AlgorithmAttribute : Attribute
    {
        public Type AlgorithmType { get; set; }

        public AlgorithmAttribute(Type algorithmType)
        {
            this.AlgorithmType = algorithmType;
        }
    }
}
