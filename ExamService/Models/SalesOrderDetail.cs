using System.ComponentModel.DataAnnotations;

namespace ExamService.Models
{
  public class SalesOrderDetail
  {
    [Key]
    [Required]
    public int id { get; set; }

      public int OrderQty { get; set; }
  }
}