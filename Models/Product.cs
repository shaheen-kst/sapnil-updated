using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sapnil.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
         public string FrameName { get; set; }
        public uint? FrameQty { get; set; }
        public decimal? FramePrice { get; set; }
        public LenseCategory? PowerLense { get; set; }
       
        public uint? PowerLenseQty { get; set;  }
        public decimal? PowerLensePrice { get; set; }
        public ContactLenseCategory? ContactLense  { get; set; }
         public uint? ContactLenseQty { get; set;  }
        public decimal? ContactLensePrice { get; set; }
        public string LeftEyeSph { get; set; }
        public string LeftEyeCyl { get; set; }
        public string LeftEyeAxis { get; set; }
        [Display(Name="N.Add")]
        public string LeftEyeAdd { get; set; }
        public string RightEyeSph { get; set; } 
        public string RightEyeCyl { get; set; }
        public string RightEyeAxis { get; set; }
        [Display(Name="N.Add")]
        public string RightEyeAdd { get; set; }
        [Display(Name="Focal Option")]
        public string FocalOption { get; set; }
        [Display(Name="Delivery Status")]
        [Required]
        public string DeliveryStatus { get; set; }
        public string Ipd { get; set; }
        
        public Customer Customer { get; set; }
    }

    public enum LenseCategory {
        White,
        [Display(Name="Crystal White")]
        CrystalWhite,
        [Display(Name="Anti Reflection")]
        AntiReflection,
       
        D,
        [Display(Name="Vari Lux")]
        VariLux,
        [Display(Name="Bluecart")]
        Bluecart,
        Moon,
        Photosun
    }
    public enum ContactLenseCategory
    {
        Aqua,
        Violet,
        [Display(Name="Misty Gray")]
        MistyGray,
        Brown,
        Green,
        Gray,
        Solution


    }
    public enum DeliveryStatus 
    {
        Not_Delivered,Delivered
    }
}