using AutoMapper;
using ExamService.Data;
using ExamService.Dtos;
using ExamService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesOrderDetailController : ControllerBase
{
    private readonly ISalesOrderDetailsRepo _repository;
    private readonly IMapper _mapper;

    public SalesOrderDetailController(
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
        Console.WriteLine("--> Getting SalesOrderDetailItems....");

        var salesOrderDetailItem = _repository.GetAllSalesOrderDetail();

        return Ok(_mapper.Map<IEnumerable<SalesOrderDetail>>(salesOrderDetailItem));
    }

    [HttpGet("{id}", Name = "GetSalesById")]
    public ActionResult<SalesOrderDetailReadDto> GetSalesById(int id)
    {
        var salesOrderDetailItem = _repository.GetSalesOrderDetailById(id);
        if (salesOrderDetailItem != null) return Ok(_mapper.Map<SalesOrderDetailReadDto>(salesOrderDetailItem));

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<SalesOrderDetailReadDto>> CreateFlight(
        SalesOrderDetailCreateDto salesOrderDetailCreateDto)
    {
        var salesOrderDetailModel = _mapper.Map<SalesOrderDetail>(salesOrderDetailCreateDto);
        _repository.CreateSalesOrderDetails(salesOrderDetailModel);
        _repository.SaveChanges();

        var salesOrderDetailModelReadDto = _mapper.Map<SalesOrderDetailReadDto>(salesOrderDetailModel);

        try
        {
            // await _bookingDataClient.SendReisToCommand(reisReadDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
        }

        return CreatedAtRoute(nameof(GetSalesById), new { id = salesOrderDetailCreateDto.SalesOrderId },
            salesOrderDetailModelReadDto);
    }
}