using WK.DA;
using WK.Shop.Model;

namespace WK.Shop.DA
{
    /********************
     * 
     * DATA ACCESS LAYER
     * 
     *******************/

    public class DABasket : IDA
    {
        // CRUD OPERATIONS
        public static Basket UpsertBasket(int? id) 
        {
            return new Basket { };
        }

        public static Basket UpsertBasket(Basket basket)
        {
            return basket;
        }
    }
}
