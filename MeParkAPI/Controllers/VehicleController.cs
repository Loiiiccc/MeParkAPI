using MeParkAPI.Models;
using MeParkAPI.Models.DTOs.VehiculeDTO;
using MeParkAPI.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace MeParkAPI.Controllers
{
    [Route("api/MePark/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult GetAllVehicles()
        {
            try
            {
                var vehicles = _vehicleService.GetAllVehicles();
                // json parssing
                // var json = vehicles.ToJson(Newtonsoft.Json.Formatting.None);
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetVehicle")]
        public IActionResult GetVehicle(string id)
        {
            try
            {
                var vehicule = _vehicleService.GetVehicleById(id);

                if (vehicule == null)
                {
                    return NotFound();
                }

                return Ok(vehicule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] AddVehicleDto vehicle)
        {
            try
            {
                var veh = _vehicleService.AddVehicle(vehicle);
                if (veh == null)
                {
                    return BadRequest();
                }
                return Ok(veh);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }


        [HttpPut("{plate}")]
        public IActionResult ModifyVehicle(string plate, [FromBody] UpdateVehicleDto vehicle)
        {
            try
            {
                if (_vehicleService.UpdateVehicle(plate, vehicle) == null)
                {
                    return BadRequest();
                }
                return Ok(vehicle);
                ///var existingVehicule = _vehicleService.GetVehicleById(id);

                //if (existingVehicule == null)
                //{
                //    return NotFound();
                //}

                //vehicle.Id = id;
                //_vehicleService.UpdateVehicle(vehicle);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(string id)
        {
            try
            {
                if (_vehicleService.RevomeVehicle(id) == false)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }


        [HttpGet("Owner/{ownerId}")]
        public IActionResult GetVehicleByOwner(string ownerId)
        {
            try
            {
                var vehicules = _vehicleService.GetVehicleByOwner(ownerId);
                return Ok(vehicules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        [HttpGet("vehicle/plate/{plate}", Name = "GetVehicleByPlate")]
        public IActionResult GetVehicleByPlate(string plate)
        {
            try
            {
                var vehicule = _vehicleService.GetVehicleByPlate(plate);

                if (vehicule == null)
                {
                    return NotFound();
                }

                return Ok(vehicule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }


    }
}
