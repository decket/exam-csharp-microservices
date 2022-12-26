using ExamService.Dtos;

namespace ExamService.SyncDataServices.Http
{
    public interface ISalesDataClient
    {
        Task SendOrderToSecondService(SpecialOfferReadDto fabric);
    }
}
