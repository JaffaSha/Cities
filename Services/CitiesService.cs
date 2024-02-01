
using Cities.Data.Repositories;
using Cities.Models;

namespace Cities.Services
{
    public class CitiesService: ICitiesService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository _repository;

        public CitiesService(IHttpContextAccessor httpContextAccessor, IRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        //Get all cities from DB
        public async Task<List<City>> GetCities()
        {
           return await _repository.GetAllCities();
        }
    }
}
