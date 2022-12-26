using ExamService.Models;

namespace ExamService.Data
{
    public class SalesOrderDetailsRepo : ISalesOrderDetailsRepo
    {
        private readonly AppDbContext _context;

        public SalesOrderDetailsRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateSalesOrderDetails(SalesOrderDetail salesOrderDetails)
        {
            if (salesOrderDetails == null)
            {
                throw new ArgumentNullException(nameof(salesOrderDetails));
            }

            _context.SalesOrderDetails.Add(salesOrderDetails);
        }

        public IEnumerable<SalesOrderDetail> GetAllSalesOrderDetail()
        {
            return _context.SalesOrderDetails.ToList();
        }

        public SalesOrderDetail GetSalesOrderDetailById(int id)
        {
            return _context.SalesOrderDetails.FirstOrDefault(r => r.SalesOrderDetailId == id)!;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}