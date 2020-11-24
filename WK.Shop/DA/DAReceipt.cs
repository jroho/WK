using WK.DA;
using WK.Shop.Model;

namespace WK.Shop.DA
{
    /********************
     * 
     * DATA ACCESS LAYER
     * 
     *******************/

    class DAReceipt : IDA
    {
        // CRUD OPERATIONS
        public static Receipt UpsertReceipt(int? id)
        {
            return new Receipt { };
        }

        public static Receipt UpsertReceipt(Receipt Receipt)
        {
            return Receipt;
        }
    }
}
