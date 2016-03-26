using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ga.Infrastructure
{
    public class Binary
    {
        private int? pointAt;
        private bool IsNegative { get { return value[0] == 1; } }
        private List<byte> value = new List<byte>();

        /// <summary>Gets the value as an enumeration of 0 and 1.</summary>
        public IEnumerable<byte> Value { get { return value; } }

        /// <summary>Gets the numeric value.</summary>
        public double NumericValue
        {
            get
            {
                double result;
                string fraction, intPart;

                if (pointAt.HasValue)
                {
                    intPart = string.Join(string.Empty, value.GetRange(1, pointAt.Value - 1));
                    fraction = string.Join(string.Empty, value.Skip(pointAt.Value));
                }
                else
                {
                    intPart = string.Join(string.Empty, value.Skip(1));
                    fraction = "0";
                }

                var intFraction = Convert.ToInt32(fraction, 2);
                var doubleStringFraction = string.Concat("0.", intFraction.ToString());
                result = Convert.ToInt32(intPart, 2) + double.Parse(doubleStringFraction, CultureInfo.InvariantCulture);
                return IsNegative ? -result : result;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Binary"/> class.</summary>
        public Binary() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Binary"/> class.
        /// </summary>
        /// <param name="x">String of 0 and 1</param>
        public Binary(string x) : this(x, 0) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Binary"/> class.
        /// </summary>
        /// <param name="x">String of 0 and 1</param>
        /// <param name="scale">Number of decimal places</param>
        public Binary(string x, int scale)
        {
            var fractionLength = GetFractionLength(scale);
            pointAt = fractionLength > 0 ? x.Length - fractionLength : (int?)null;
            value.AddRange(x.ToCharArray().Select(y => (byte)char.GetNumericValue(y)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Binary"/> class.
        /// </summary>
        /// <param name="x">Numeric value</param>
        public Binary(double x) : this(x, 0) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Binary"/> class.
        /// </summary>
        /// <param name="x">Numeric value</param>
        /// <param name="scale">Number of decimal places</param>
        public Binary(double x, int scale) : this(x, scale, x, -x) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Binary"/> class.
        /// </summary>
        /// <param name="x">Numeric value</param>
        /// <param name="scale">Number of decimal places</param>
        /// <param name="maxValue">Maximum value</param>
        /// <param name="minValue">Minumum value</param>
        public Binary(double x, int scale, double maxValue, double minValue)
        {
            ResolveMinusSign(ref x);

            long intPart = (long)Math.Floor(x);
            value.AddRange(BitsFromInteger(intPart));

            double fraction = x - intPart;
            if (fraction != 0)
            {
                pointAt = value.Count;
                var strFraction = fraction.ToString(CultureInfo.InvariantCulture);
                var intFraction = long.Parse(strFraction.Substring(strFraction.IndexOf('.') + 1));
                value.AddRange(BitsFromInteger(intFraction));
            }

            AdjustValue(scale, Math.Max(maxValue, -minValue));
        }

        /// <summary>
        /// Concats two binaries.
        /// </summary>
        /// <param name="other">Second binary</param>
        /// <returns>Concatenation of the binaries</returns>
        public Binary Concat(Binary other)
        {
            return new Binary { value = this.value.Concat(other.value).ToList() };
        }

        /// <summary>
        /// Performs AND operation on the binaries.
        /// </summary>
        /// <param name="other">Second binary</param>
        /// <returns>Result of the AND operation</returns>
        public Binary And(Binary other)
        {
            if (value.Count != other.value.Count)
            {
                throw new InvalidOperationException("Arguments have different length.");
            }

            if (pointAt != other.pointAt)
            {
                throw new InvalidOperationException("Arguments have different precision.");
            }

            var result = new Binary { pointAt = pointAt };
            for (int i = 0; i < value.Count; i++)
            {
                result.value.Add((byte)(value[i] & other.value[i]));
            }

            return result;
        }

        /// <summary>
        /// Performs AND operation on the binaries.
        /// </summary>
        /// <param name="other">Second binary</param>
        /// <returns>Result of the AND operation</returns>
        public static Binary operator &(Binary b1, Binary b2)
        {
            return b1.And(b2);
        }

        /// <summary>
        /// Performs OR operation on the binaries.
        /// </summary>
        /// <param name="other">Second binary</param>
        /// <returns>Result of the OR operation</returns>
        public Binary Or(Binary other)
        {
            if (value.Count != other.value.Count)
            {
                throw new InvalidOperationException("Arguments have different length.");
            }

            if (pointAt != other.pointAt)
            {
                throw new InvalidOperationException("Arguments have different precision.");
            }

            var result = new Binary { pointAt = pointAt };
            for (int i = 0; i < value.Count; i++)
            {
                result.value.Add((byte)(value[i] | other.value[i]));
            }

            return result;
        }

        /// <summary>
        /// Performs OR operation on the binaries.
        /// </summary>
        /// <param name="other">Second binary</param>
        /// <returns>Result of the OR operation</returns>
        public static Binary operator |(Binary b1, Binary b2)
        {
            return b1.Or(b2);
        }

        /// <summary>
        /// Returns the substring of the binary.
        /// </summary>
        /// <param name="start">Starting index</param>
        /// <param name="count">Number of digits to take</param>
        /// <returns>Substring of the binary</returns>
        public Binary Subbinary(int start, int count)
        {
            return new Binary { value = value.GetRange(start, count) };
        }

        /// <summary>
        /// Reverts the digit at the specified index.
        /// </summary>
        /// <param name="i">The index of the digit to revert</param>
        public void Revert(int i)
        {
            value[i] = (byte)(value[i] == 1 ? 0 : 1);
        }

        public override string ToString()
        {
            return string.Join(string.Empty, Value);
        }

        private void ResolveMinusSign(ref double x)
        {
            if (x < 0)
            {
                x *= -1;
                value.Add(1);
            }
            else
            {
                value.Add(0);
            }
        }

        private IEnumerable<byte> BitsFromInteger(long x)
        {
            return Convert.ToString(x, 2).ToCharArray().Select(y => (byte)char.GetNumericValue(y));
        }

        private void AdjustValue(int scale, double maxValue)
        {
            maxValue *= maxValue < 0 ? -1 : 1;
            int maxValueLength = Convert.ToString((long)maxValue, 2).Length + 1;
            var insertBefore = 0;
            if (pointAt.HasValue && pointAt < maxValueLength)
            {
                insertBefore = maxValueLength - pointAt.Value;
            }
            else if (value.Count < maxValueLength)
            {
                insertBefore = maxValueLength - value.Count;
            }

            for (int i = 0; i < insertBefore; i++)
            {
                pointAt++;
                value.Insert(1, 0);
            }

            var fractionLenth = GetFractionLength(scale);
            if (pointAt.HasValue && value.Skip(pointAt.Value).Count() < fractionLenth)
            {
                insertBefore = fractionLenth - value.Skip(pointAt.Value).Count();
                for (int i = 0; i < insertBefore; i++)
                {
                    value.Insert(pointAt.Value, 0);
                }
            }
        }

        private int GetFractionLength(int scale)
        {
            var fractionLenth = 0;

            var maxfraction = string.Empty;
            for (int i = 0; i < scale; i++)
            {
                maxfraction += "9";
            }

            if (maxfraction.Length > 0)
            {
                fractionLenth = Convert.ToString(int.Parse(maxfraction), 2).Length;
            }

            return fractionLenth;
        }
    }
}
