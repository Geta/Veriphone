using System;

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
    }
}
