using System.ComponentModel.DataAnnotations;

namespace ExamService.Dtos
{
    public class SalesOrderDetailCreateDto
    {
        public int OrderQty { get; set; }

        public int UnitPrice { get; set; }

        public int UnitPriceDiscount { get; set; }

        public int LineTotal { get; set; }

        public int rowguid { get; set; }

        public int ModifiedDate { get; set; }
    }
}