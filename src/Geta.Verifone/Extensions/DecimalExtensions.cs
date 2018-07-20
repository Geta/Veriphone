using System;

namespace Geta.Verifone.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToVerifoneAmountString(this decimal amount)
        {
            return ((int)(Math.Round(amount * 100, 0))).ToString();
        }
    }
}
