 
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace  Sapnil.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Display(Name="Invoice No.")]
        public uint InvoiceNo { get; set; }
        [Display(Name ="Name")]
        [StringLength(50),Required]
        public string Name { get; set; }
       
        [StringLength(11, ErrorMessage="Mobile number must have 11 digits")]
        [Required]
        [RegularExpression(@"^[0-9]{11}$",ErrorMessage="Plz, enter a 11 digit valid mobile number.")]
        [Display(Name="Cell No.")]
        public String CellNo { get; set; }
        [Display(Name="Address")]
        public string Address { get; set; }
        [Display(Name="Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        [Display(Name="Delivery Date")]
        public DateTime DeliveryDate { get; set; }
        [Display(Name="Frame Name")]
        public string FrameName { get; set; }
        [Display(Name="Quantity")]
        public uint? FrameQty { get; set; }
        [Display(Name="Price")]
        public decimal? FramePrice { get; set; }
        [Display(Name="Power Lense")]
        public LenseCategory? PowerLense { get; set; }
        [Display(Name="Quantity")]

        public uint? PowerLenseQty { get; set;  }
        [Display(Name="Price")]

        public decimal? PowerLensePrice { get; set; }
        [Display(Name="Contact Lense")]
        public ContactLenseCategory? ContactLense  { get; set; }
        [Display(Name="Quantity")]
         public uint? ContactLenseQty { get; set;  }
         [Display(Name="Price")]
        public decimal? ContactLensePrice { get; set; }
        [Display(Name="Sph")]
        public string LeftEyeSph { get; set; }
        [Display(Name="Cyl")]
        public string LeftEyeCyl { get; set; }
        [Display(Name="Axis")]
        public string LeftEyeAxis { get; set; }
        [Display(Name="N.Add")]
        public string LeftEyeAdd { get; set; }
        [Display(Name="Sph")]
        public string RightEyeSph { get; set; }
        [Display(Name="Cyl")]
        public string RightEyeCyl { get; set; }
        [Display(Name="Axis")]
        public string RightEyeAxis { get; set; }
        [Display(Name="N.Add")]
        public string RightEyeAdd { get; set; }
        [Display(Name="Focal Option")]

        public string FocalOption { get; set; }
        [Display(Name="Delivery Status")]
        [Required]
        public string DeliveryStatus { get; set;}
        
        [Display(Name="Total Amount")]
        public decimal TotalAmmount { get; set; }
        [Display(Name="Discount Amount")]
        public decimal? DiscountAmount { get; set; }
        [Display(Name="Net Amount")]
        public decimal NetAmount { get; set; }
        [Display(Name="Paid Amount")]
        public decimal? PaidAmount { get;set;}
        [Display(Name="Due Amount")]
        public decimal? DueAmount { get; set; }
        public DateTime? EntryDate { get; set; }

      
    }
}
