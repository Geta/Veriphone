using System;
using System.Globalization;

namespace Geta.Commerce.Payments.Verifone.HostedPages.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToVerifoneAmountString(this decimal amount)
        {
            return ((int)(Math.Round(amount * 100, 0))).ToString();
        }
    }
}
