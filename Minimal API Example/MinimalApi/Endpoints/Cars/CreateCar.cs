using MinimalApi.Models;
using MinimalApi.Persistence;
using MinimalApi.Repository;

namespace MinimalApi.Endpoints.Cars
{
    public class CreateCar : Endpoint<Car>
    {
        private readonly ICarsRepository _repository;

        public override void Configure()
        {
            Post("/cars");
            AllowAnonymous();
        }

        public CreateCar(ICarsRepository repository)
        {
            _repository = repository;
        }

        public override async Task HandleAsync(Car req, CancellationToken ct)
        {
            var createdCar = _repository.Create(req);
            await SendCreatedAtAsync<GetCar>(
                new { id = createdCar.Id },
                createdCar,
                generateAbsoluteUrl: true,
                cancellation: ct);
        }
    }
}
