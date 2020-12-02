using System;
using System.Collections.Generic;

namespace DataManagers
{
    public class ItemToAddressable
    {
        private static Dictionary<string, string> _items = new Dictionary<string, string>()
        {
            ["Кукуруза"] = "Corn.png",
            ["Масло"] = "Butter.png",
            ["Грибы"] = "Mushrooms.png",
            ["Сахарный тростник"] = "Wheat.png",
            ["Томат"] = "Tomato.png"
        };

        public static string GetAddressableByItemName(string itemName)
        {
            if (!_items.ContainsKey(itemName))
            {
                throw new IndexOutOfRangeException($"{itemName} is unknown addressable");
            }
            return _items[itemName];
        }
    }
}
