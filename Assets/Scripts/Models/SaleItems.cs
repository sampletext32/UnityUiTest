using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using UnityEngine.Serialization;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class SaleItems
    {
        public List<SaleItem> Items { get; set; }

        public SaleItems()
        {
            Items = new List<SaleItem>();
        }
    }
}