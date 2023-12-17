using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Business.Abstract;
using TravelAgency.DataAcces.DTOs.Reservation;

namespace TravelAgency.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    { 
    private IReservationService _service { get; set; }
    public ReservationsController(IReservationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetReservationsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservationById(int id)
    {
        var reservation = await _service.GetReservationByIdAsync(id);
        if (reservation != null)
        {
            return Ok(reservation);//200 + data
        }
        return BadRequest(); //400
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateReservationDTO reservation)
    {
        var createdReservation = await _service.CreateReservationAsync(reservation);
        return Ok(createdReservation); //200 + data
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateReservationDTO reservation)
    {
        return Ok(await _service.UpdateReservationAsync(reservation));//200 + data
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await _service.GetReservationByIdAsync(id) != null)
        {
            await _service.DeleteReservationAsync(id);
            return Ok();//200 + data
        }
        return BadRequest();//400
    }
}
}
