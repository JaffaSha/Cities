
using Cities.Data.Repositories;
using Cities.Models;

namespace Cities.Services
{
    public interface ICitiesService
    {
        Task<List<City>> GetCities();
    }
}
