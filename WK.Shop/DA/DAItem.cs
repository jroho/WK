using WK.DA;
using WK.Shop.Model;

namespace WK.Shop.DA
{
    /********************
     * 
     * DATA ACCESS LAYER
     * 
     *******************/

    class DAItem : IDA
    {
        // CRUD OPERATIONS
        public static Item UpsertItem(int? id)
        {
            return new Item { };
        }

        public static Item UpsertItem(Item Item)
        {
            return Item;
        }
    }
}
