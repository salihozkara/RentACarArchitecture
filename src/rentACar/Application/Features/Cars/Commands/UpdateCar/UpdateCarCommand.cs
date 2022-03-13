using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands.UpdateCar;

public class UpdateCarCommand:IRequest<UpdatedCarDto>
{
    // Domain.Entities.Car Properties ignored Navigation Properties
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public CarState CarState { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarDto>
    {
        // Car Repository
        private readonly ICarRepository _carRepository;
        // Mapper
        private readonly IMapper _mapper;
        
        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        // Handle
        public async Task<UpdatedCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            // Map request to domain.Entities.Car
            _mapper.Map(request, car);
            // Update
            await _carRepository.UpdateAsync(car);
            // Return Dto
            return _mapper.Map<UpdatedCarDto>(car);
        }
    }
}