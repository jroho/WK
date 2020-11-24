namespace WK.Shop.Model
{
    public enum ItemType
    { 
        Book = 0,
        Food,
        Medical,
        Other
    }

    public class Item
    {
        /*************************************************************
         * Considering a basket can have many items, and vice versa
         * I would abstract the Item model out into BasketItem to
         * appropriately handle the Associative Entity
         * 
         * For simplicities sake regarding the scope of this project,
         * I choose to just add quantity to the Item's Data Structure
         *************************************************************/

        #region "Data Members"

        public int Id { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public bool IsImported { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }

        // The members below would be abstracted into a BasketItem object
        public int Quantity { get; set; }
        public decimal TotalTax { get; set; }

        #endregion

        #region "Constructors"
        public Item() { }

        public Item(int? id)
        {

        }
        #endregion
    }
}
