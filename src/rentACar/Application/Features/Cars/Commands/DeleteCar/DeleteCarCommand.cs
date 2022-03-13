using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.DeleteCar;

public class DeleteCarCommand : IRequest<DeletedCarDto>
{
    public int Id { get; set; }
    
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarDto>
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

        public async Task<DeletedCarDto> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            // if (car == null)
            // {
            //     throw new NotFoundException(nameof(Car), request.Id);
            // }

            await _carRepository.DeleteAsync(car);
            var deletedCarDto = _mapper.Map<DeletedCarDto>(car);
            return deletedCarDto;

        }
    }
}