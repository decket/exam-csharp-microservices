using System.ComponentModel.DataAnnotations;

namespace ExamService.Models
{
    public class SpecialOfferCreateDto
    {
        public int SpecialOfferId { get; set; }
        public string? DiscountPct { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinQty { get; set; }
        public int MaxQty { get; set; }
        public int Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}