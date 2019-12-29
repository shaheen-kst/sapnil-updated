using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sapnil.Models
{
    public class PurchasedItemVM
    {
        public string ItemName { get; set; }
        public uint? ItemQty { get; set; }
        public decimal? Itemprice { get; set; }
       
       
    }
}