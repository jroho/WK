using System;
using System.Configuration;
using WK.Shop.Model;

namespace WK.Shop.Helpers
{
    public static class TaxCalculator
    {
        private static decimal BaseTax = System.Convert.ToDecimal(ConfigurationSettings.AppSettings["BaseTax"].ToString());
        private static decimal ImportTax = System.Convert.ToDecimal(ConfigurationSettings.AppSettings["ImportTax"].ToString());

        public static decimal CalculateTax(Item item)
        {
            var totalTax = default(decimal);
            var taxRate = BaseTax;

            // Set tax rate to 0 if it's exempt from sales tax
            if (item.Type == ItemType.Book ||
                item.Type == ItemType.Food ||
                item.Type == ItemType.Medical)
                taxRate = 0;

            if (item.IsImported)
                taxRate += 5;

            // Calculate tax
            totalTax = (taxRate * item.Price) / 100M;
            // Round to nearest .05
            totalTax = Math.Ceiling(totalTax * 20) / 20;

            return totalTax;
        }
    }
}
