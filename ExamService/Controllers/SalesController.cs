using AutoMapper;
using ExamService.Data;
using ExamService.Dtos;
using ExamService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly ISalesOrderDetailsRepo _repository;
        private readonly IMapper _mapper;

        public FlightsController(
            ISalesOrderDetailsRepo repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesOrderDetailReadDto>> GetFlights()
        {
            Console.WriteLine("--> Getting Flights....");

            var reisItem = _repository.GetAllSalesOrderDetail();

            return Ok(_mapper.Map<IEnumerable<SalesOrderDetail>>(reisItem));
        }

        [HttpGet("{id}", Name = "GetFlightById")]
        public ActionResult<SalesOrderDetailReadDto> GetReisById(int id)
        {
            var reisItem = _repository.GetSalesOrderDetailById(id);
            if (reisItem != null)
            {
                return Ok(_mapper.Map<SalesOrderDetailReadDto>(reisItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<SalesOrderDetailReadDto>> CreateFlight(FlightCreateDto salesOrderDetailCreateDto)
        {
            var reisModel = _mapper.Map<SalesOrderDetail(reisCreateDto);
            _repository.CreateSalesOrderDetails(reisModel);
            _repository.SaveChanges();

            var reisReadDto = _mapper.Map<FlightReadDto>(reisModel);

            try
            {
                await _bookingDataClient.SendReisToCommand(reisReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetReisById), new { id = reisReadDto.id }, reisReadDto);
        }
    }
}