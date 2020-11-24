using System.Text;
using WK.Shop.Base;

namespace WK.Shop.Model
{
    public class Receipt : IBasket
    {

        #region "Data Members"

        public int Id { get; set; }
        Basket Basket { get; set; }

        #endregion

        #region "Constructors"
        public Receipt() 
        {
        }

        public Receipt(int? id)
        {

        }

        public Receipt(Basket basket)
        {
            this.Basket = basket;
        }
        #endregion

        #region "Logic"
        
        public string PrintReceipt()
        {
            StringBuilder sbReceipt = new StringBuilder();
            foreach (Item item in this.Basket.Items)
            {
                sbReceipt.AppendLine(item.Quantity + " " + item.Name + ": " + string.Format("{0:C}", (item.Price + item.TotalTax)));
            }
            
            // Append total sales tax
            sbReceipt.AppendLine("Sales Tax: " + string.Format("{0:C}", this.Basket.TotalTax));
            // Append total
            sbReceipt.AppendLine("Total: " + string.Format("{0:C}", this.Basket.Total));

            return sbReceipt.ToString();
        }
        
        #endregion
    }
}
