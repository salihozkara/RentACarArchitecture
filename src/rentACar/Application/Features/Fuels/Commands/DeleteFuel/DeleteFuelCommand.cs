using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.DeleteFuel;

public class DeleteFuelCommand:IRequest<Fuel>
{
    public int Id { get; set; }
    // DeleteFuelCommandHandler
    public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, Fuel>
    {
        private readonly IFuelRepository _fuelRepository;
        // Mapper
        private readonly IMapper _mapper;
        // ctor
        public DeleteFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }
        public async Task<Fuel> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
        {
            var fuel = _mapper.Map<Fuel>(request);
            // if (fuel == null)
            //     throw new NotFoundException(nameof(Fuel), request.Id);
            await _fuelRepository.DeleteAsync(fuel);
            return fuel;
        }
    }
}