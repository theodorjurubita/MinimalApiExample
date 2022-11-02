using MinimalApi.Models;
using MinimalApi.Repository;

namespace MinimalApi.Endpoints.Cars
{
    /// <summary>
    /// Here are defined the endpoints for handling cars.
    /// </summary>
    public class GetCars : EndpointWithoutRequest<List<Car>>
    {
        private readonly ICarsRepository carsRepository;

        public override void Configure()
        {
            Get("/cars");
            AllowAnonymous();
        }

        public GetCars(ICarsRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public override async Task<List<Car>> ExecuteAsync(CancellationToken ct)
        {
            var carsList =  carsRepository.Get();

            await SendAsync(carsList, cancellation: ct);

            return carsList;
        }

    }
}
