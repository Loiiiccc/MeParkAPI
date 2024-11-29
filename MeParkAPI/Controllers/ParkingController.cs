using MeParkAPI.Models.DTOs.VehiculeDTO;
using MeParkAPI.Models;
using MeParkAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MeParkAPI.Models.DTOs.ParkingDTO;
using Mapster;

namespace MeParkAPI.Controllers
{
    [Route("api/MePark/[controller]")]
    [ApiController]
    public class ParkingController : Controller
    {
        private readonly ParkingService _parkingService;

        public ParkingController(ParkingService parkingService)
        {
            _parkingService = parkingService;
        }


        [HttpGet]
        public IActionResult GetAllParkings()
        {
            try
            {
                var parkings = _parkingService.GetAllParkings();
                return Ok(parkings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetParking")]
        public IActionResult GetParking(string id)
        {
            try
            {
                var parking = _parkingService.GetParkingById(id);

                if (parking == null)
                {
                    return NotFound();
                }

                return Ok(parking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateParking([FromBody] AddParkingDto parking)
        {
            try
            {
                _parkingService.AddParking(parking);
                //return CreatedAtRoute("GetParking", /*new { id = vehicule.Id },*/ parking);
                return Ok(parking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult ModifyParking(string id, [FromBody] UpdateParkingDto parking)
        {
            try
            {
                var existingParking = _parkingService.GetParkingById(id);

                if (existingParking == null)
                {
                    return NotFound();
                }

                
                if(!_parkingService.UpdateParkingSpaces(id, parking.Capacity))
                {
                    return BadRequest("Parking spaces not updated !");
                }
                var park = _parkingService.UpdateParking(parking);

                return Ok(park);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteParking(string id)
        {
            try
            {
                var vehicule = _parkingService.GetParkingById(id);

                if (vehicule == null)
                {
                    return NotFound();
                }

                _parkingService.RevomeParking(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

    }
}
