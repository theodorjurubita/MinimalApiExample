using MinimalApi.Models;

namespace MinimalApi.Repository
{
    public interface ICarsRepository
    {
        List<Car> Get();

        Car Get(int id);

        Car Create(Car car);
    }
}
