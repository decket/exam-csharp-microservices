using System.ComponentModel.DataAnnotations;

namespace ExamService.DTOS
{
  public class SalesOrderDetailReadDTO {
      public int id { get; set; }

      public int OrderQty { get; set; }

      public int UnitPrice { get; set; }

      public int UnitPriceDiscount { get; set; }

      public int LineTotal { get; set; }

      public int rowguid { get; set; }

      public int ModifiedDate { get; set; }
    }
}
