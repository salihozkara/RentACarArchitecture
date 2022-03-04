using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.DeleteCar;

public class DeleteCarCommand : IRequest<Car>
{
    public int Id { get; set; }
    
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Car>
    {
        // Car repository
        private readonly ICarRepository _carRepository;
        // Mapper
        private readonly IMapper _mapper;

        public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Car> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            // if (car == null)
            // {
            //     throw new NotFoundException(nameof(Car), request.Id);
            // }

            await _carRepository.DeleteAsync(car);

            return car;
        }
    }
}