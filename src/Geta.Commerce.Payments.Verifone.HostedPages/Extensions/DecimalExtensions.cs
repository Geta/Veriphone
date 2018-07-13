using System;
using System.Globalization;

namespace Geta.Commerce.Payments.Verifone.HostedPages.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToVerifoneAmountString(this decimal number)
        {
            return ((int)(Math.Round(number, 2)*100)).ToString();
        }
    }
}
