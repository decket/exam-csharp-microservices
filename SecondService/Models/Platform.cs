using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecondService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ExternalID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<SpecialOffer> Offers { get; set; } = new List<SpecialOffer>();
     }
}