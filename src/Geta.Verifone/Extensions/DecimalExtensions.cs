using System;
using System.Globalization;

namespace Geta.Verifone.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Converts decimal amount to string representation without decimal separator
        /// </summary>
        /// <param name="amount">Decimal amount</param>
        /// <returns>Verifone amount string</returns>
        /// <example>645.00 returns 64500</example>
        public static string ToVerifoneAmountString(this decimal amount)
        {
            // multiply to move decimal point 2 places and round to whole number
            return ((int)(Math.Round(amount * 100, 0))).ToString();
        }

        
        /// <summary>
        /// Parses verifone amount string to decimal value with last two digits as two decimal places
        /// </summary>
        /// <param name="amountString">Verifone amount string</param>
        /// <returns>Decimal amount</returns>
        /// <example>1972 returns 19.72</example>
        public static decimal FromVerifoneAmountString(this string amountString)
        {
            var value = decimal.Parse(amountString, NumberStyles.Integer, CultureInfo.InvariantCulture);
            return value * 0.01m ;            
        }
    }
}
