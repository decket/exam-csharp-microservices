using ExamService.Models;

namespace ExamService.Data
{
  public interface ISalesOrderDetailsRepo
  {
    bool SaveChanges();
    IEnumerable<SalesOrderDetail> GetAllSalesOrderDetail();
    SalesOrderDetail GetSalesOrderDetailById(int id);
    void CreateSalesOrderDetails(SalesOrderDetail salesOrderDetails);
  }
}