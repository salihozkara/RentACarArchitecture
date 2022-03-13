using Application.Features.Fuels.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.UpdateFuel;

public class UpdateFuelCommand : IRequest<UpdatedFuelDto>
{
    // Domain.Entities.Fuel Properties
    public int Id { get; set; }
    public string Name { get; set; }

    // Handlers
    public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdatedFuelDto>
    {
        // Fuel Repository
        private readonly IFuelRepository _fuelRepository;

        // Mapper
        private readonly IMapper _mapper;

        // Ctor
        public UpdateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        // Handle
        public async Task<UpdatedFuelDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
        {
            var fuel = _mapper.Map<Fuel>(request);
            if (fuel == null)
            {
                throw new Exception("Fuel not found");
            }

            await _fuelRepository.UpdateAsync(fuel);
            var updatedFuelDto = _mapper.Map<UpdatedFuelDto>(fuel);
            return updatedFuelDto;
        }
    }
}