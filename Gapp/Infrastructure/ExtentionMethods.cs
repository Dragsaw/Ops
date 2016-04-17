using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gapp.Infrastructure
{
    public static class ExtentionMethods
    {
        public static Type GetAlgorithmType(this Enum value)
        {
            var algorithmAttribute = value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(AlgorithmAttribute), false)
                .FirstOrDefault() as AlgorithmAttribute;

            if (algorithmAttribute == null)
            {
                return null;
            }

            return algorithmAttribute.AlgorithmType;
        }
    }
}
