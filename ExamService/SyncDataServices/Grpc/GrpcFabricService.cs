using AutoMapper;
using ExamService.Data;
using ExamService.Protos;
using Grpc.Core;

namespace ExamService.SyncDataServices.Grpc
{
    public class GrpcSalesModel : GrpcFabric.GrpcFabricBase
    {
        private readonly ISalesOrderDetailsRepo _repository;
        private readonly ILogger<GrpcSalesModel> _logger;
        private readonly IMapper _mapper;

        public GrpcSalesModel(ISalesOrderDetailsRepo repository, ILogger<GrpcSalesModel> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public override Task<FabricResponse> GetAllSales(GetAllRequest request, ServerCallContext context)
        {
            var response = new FabricResponse();
            var sales = _repository.GetAllSales();

            foreach (var sale in sales)
            {
                response.Fabric.Add(_mapper.Map<GrpcSaleModel>(sale));
            }

            return Task.FromResult(response);
        }
    }
}
