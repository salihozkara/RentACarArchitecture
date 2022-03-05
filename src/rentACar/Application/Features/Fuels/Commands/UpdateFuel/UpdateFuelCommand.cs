using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.UpdateFuel;

public class UpdateFuelCommand : IRequest<Fuel>
{
    // Domain.Entities.Fuel Properties
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Handlers
    public class UpdateFuelCommandHandler:IRequestHandler<UpdateFuelCommand,Fuel>
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
        public async Task<Fuel> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
        {
            var fuel = _mapper.Map<Fuel>(request);
            if (fuel == null)
            {
                throw new Exception("Fuel not found");
            }
            await _fuelRepository.UpdateAsync(fuel);
            return fuel;
        }
    }
}