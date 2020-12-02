using System;

namespace Models
{
    [Serializable]
    public class SaleItem
    {
        public ItemData ItemData { get; }
        public UserData UserData { get; }

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