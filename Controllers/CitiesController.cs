using Cities.Data.Repositories;
using Cities.Models;
using Cities.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cities.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesManagementController : ControllerBase
    {
        private readonly ICitiesService _citiesService;

        public CitiesManagementController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetCities()
        {
            try
            {

            var response = await _citiesService.GetCities();
            if (response == null)
            {
                    return Problem("תקלה בשליפת דתה");
            }
            return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    
    }
}
