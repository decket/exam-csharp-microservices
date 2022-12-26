using System.ComponentModel.DataAnnotations;

namespace ExamService.Models
{
    public class SpecialOfferProductReadDto
    {
        public int SpecialOfferId { get; set; }
        public int Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}