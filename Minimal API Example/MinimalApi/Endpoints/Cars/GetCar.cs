using MinimalApi.Models;
using MinimalApi.Repository;

namespace MinimalApi.Endpoints.Cars
{
    public class GetCar : EndpointWithoutRequest<Car>
    {
        private readonly ICarsRepository carsRepository;

        public override void Configure()
        {
            Get("/cars/{id}");
            //Route<int>("id", false);
            AllowAnonymous();
        }

        public GetCar(ICarsRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public override async Task<Car> ExecuteAsync(CancellationToken ct)
        {
            var id = Route<int>("id");

            var car = carsRepository.Get(id);

            await SendAsync(car, cancellation: ct);

            return car;
        }
    }
}
