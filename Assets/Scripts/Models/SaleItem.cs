using System;

namespace Models
{
    [Serializable]
    public class SaleItem
    {
        public ItemData ItemData { get; set; }
        public UserData UserData { get; set; }

        public SaleItem()
        {
        }

        public SaleItem(ItemData itemData, UserData userData)
        {
            ItemData = itemData;
            UserData = userData;
        }
    }
}