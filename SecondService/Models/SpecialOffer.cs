using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecondService.Models
{
    public class SpecialOffer
    {
        [Key]
        [Required]
        public int SpecialOfferId { get; set; }
        [Required]
        public string? DiscountPct { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Category { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int MinQty { get; set; }
        [Required]
        public int MaxQty { get; set; }
        [Required]
        public int Rowguid { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}