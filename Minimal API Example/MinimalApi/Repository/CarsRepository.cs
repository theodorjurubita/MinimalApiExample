using MinimalApi.Models;
using MinimalApi.Persistence;

namespace MinimalApi.Repository
{
    public class CarsRepository : ICarsRepository
    {
        private readonly EndpointsDbContext _context;

        public CarsRepository(EndpointsDbContext context)
        {
            _context = context;
        }

        public List<Car> Get() => _context.Cars.ToList();

        public Car Get(int id) => _context.Cars.Single(c => c.Id == id);

        public Car Create(Car car)
        {
            var createdCar = _context.Cars.Add(car);
            _context.SaveChanges();
            return createdCar.Entity;
        }
    }
}
