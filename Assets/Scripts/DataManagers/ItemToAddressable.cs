using System;
using System.Collections.Generic;

namespace DataManagers
{
    public class ItemToAddressable
    {
        private static Dictionary<string, string> Items = new Dictionary<string, string>()
        {
            ["Кукуруза"] = "_orn.png",
            ["Масло"] = "_utter.png",
            ["Грибы"] = "_ushrooms.png",
            ["Сахарный тростник"] = "_heat.png",
            ["Томат"] = "_omato.png"
        };

        public static string GetAddressableByItemName(string itemName)
        {
            if (!Items.ContainsKey(itemName))
            {
                throw new IndexOutOfRangeException($"{itemName} is unknown addressable");
            }
            return Items[itemName];
        }
    }
}
