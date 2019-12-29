using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sapnil.Models
{
    public class ReceiptVM
    {
        public uint InvoiceNo { get; set; }
        public string Name { get; set; }
        public string CellNo { get; set; }
        public string Address { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public ICollection<PurchasedItemVM> PurchasedItems { get; set; }
    }
}