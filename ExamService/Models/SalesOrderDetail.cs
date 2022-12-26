using System.ComponentModel.DataAnnotations;

namespace ExamService.Models
{
    public class SalesOrderDetail
    {
        public int SalesOrderId { get; set; }
        public int SalesOrderDetailId { get; set; }
        public int OrderQty { get; set; }
        public int ProductId { get; set; }
        public int SpecialOfferId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public int LineTotal { get; set; }
        public int Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}