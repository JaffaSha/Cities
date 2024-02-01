using Cities.Models;

namespace Cities.Data.Repositories
{
    public interface IRepository
    {
        Task<List<City>> GetAllCities();
    }
}
