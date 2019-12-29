using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sapnil.Models
{
    public class  Payment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Required]
         public decimal TotalAmmount { get; set; } 
        public decimal? DiscountAmount { get; set; }
        [Required]
        public decimal NetAmount { get; set; }
        public decimal? PaidAmount { get;set;}
        public decimal? DueAmount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EntryDate { get; set; }
        public Customer Customer { get; set; }
    }
}