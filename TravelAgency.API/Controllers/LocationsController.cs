using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Business.Abstract;
using TravelAgency.DataAcces.Abstract;
using TravelAgency.DataAcces.DTOs.Location;

namespace TravelAgency.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private ILocationService _service { get; set; }
        public LocationsController(ILocationService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _service.GetLocationsAsync();
            return Ok(locations); //200 + data
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _service.GetLocationByIdAsync(id);
            if (location != null)
            {
                return Ok(location);//200 + data
            }
            return BadRequest(); //400
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLocationDTO location)
        {
            var createdLocation = await _service.CreateLocationAsync(location);
            return Ok(createdLocation); //200 + data
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateLocationDTO location)
        {
            return Ok(await _service.UpdateLocationAsync(location));//200 + data
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.GetLocationByIdAsync(id) != null)
            {
                await _service.DeleteLocationAsync(id);
                return Ok();//200 + data
            }
            return BadRequest();//400
        }


    }
}
