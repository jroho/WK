using System.Collections.Generic;
using System.Text;
using WK.Shop.Base;
using WK.Shop.Helpers;

namespace WK.Shop.Model
{
    public class Basket : IBasket
    {

        #region "Data Members"

        public int Id { get; set; }
        public int Status { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalTax { get; set; }
        public decimal Total { get; set; }

        public List<Item> Items { get; set; }

        #endregion

        #region "Constructors"
        public Basket() { }

        public Basket(int? id)
        {

        }
        #endregion

        #region "Logic"

        /// <summary>
        ///     Updates the status of the Basket, calculates tax and totals, and builds Receipt oject
        /// </summary>
        /// <returns>Receipt</returns>
        public Receipt ProcessBasket()
        { 
            //Calculate Totals
            foreach (Item item in Items)
            {
                //Calculate Tax
                item.TotalTax += TaxCalculator.CalculateTax(item);

                //Add to Basket's TotalTax
                this.TotalTax += item.TotalTax;

                //Add to Basket's SubTotal
                this.SubTotal += item.Price * item.Quantity;
            }

            //Add to Basket's Total
            this.Total += this.SubTotal + this.TotalTax;

            return new Receipt(this);
        }

        public string PrintBasket()
        {
            StringBuilder sbBasket = new StringBuilder();
            foreach (Item item in this.Items)
            {
                sbBasket.AppendLine(item.Quantity + " " + item.Name + " at " + string.Format("{0:C}", item.Price));
            }

            return sbBasket.ToString();
        }

        #endregion
    }
}
