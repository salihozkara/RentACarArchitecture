using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands.CreateCar;

public class CreateCarCommand:IRequest<Car>
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
    {
        // Car Properties
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public int RentalBranchId { get; set; }
        public CarState CarState { get; set; }
        public int Kilometer { get; set; }
        public short ModelYear { get; set; }
        public string Plate { get; set; }
        
        // Car Repository
        private readonly ICarRepository _carRepository;
        // Mapper
        private readonly IMapper _mapper;

        public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            await _carRepository.AddAsync(car);
            
            return car;
        }
    }
}