using Cities.Data.DataBaseContext;
using Cities.Models;
using Microsoft.EntityFrameworkCore;

namespace Cities.Data.Repositories
{
    public class CitiesRepository : IRepository
    {
        private DataContext _dataContext;

        public CitiesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Get all data from Cities table
        public async Task<List<City>> GetAllCities()
        {
            try
            {
                var result = await _dataContext.Cities.OrderBy(c => c.CityName).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
