using System;

namespace Assets.Scripts
{
    [Serializable]
    public class SaleItem
    {
        public string ItemName { get; set; }
        public int ItemAmount { get; set; }
        public int ItemCost { get; set; }

        public string UserName { get; set; }
        public int UserStars { get; set; }

        public SaleItem(string itemName, int itemAmount, int itemCost, string userName, int userStars)
        {
            ItemName = itemName;
            ItemAmount = itemAmount;
            ItemCost = itemCost;
            UserName = userName;
            UserStars = userStars;
        }
    }
}