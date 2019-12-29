using System;
using System.ComponentModel.DataAnnotations;

namespace Sapnil.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name="Invoice No.")]
        public uint InvoiceNo { get; set; }
        [StringLength(50),Required]
        public string Name { get; set; }
        [StringLength(11),Required]
        [Display(Name="Cell No.")]
        public string CellNo { get; set; }
        public string Address { get; set; }
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name="Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name="Delivery Date")]
        public DateTime DeliveryDate { get; set; }
        public Product Product { get; set; }
        public Payment Payment { get; set;}
    }
}