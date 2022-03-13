using Application.Features.Fuels.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.DeleteFuel;

public class DeleteFuelCommand:IRequest<DeletedFuelDto>
{
    public int Id { get; set; }
    // DeleteFuelCommandHandler
    public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, DeletedFuelDto>
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
        public async Task<DeletedFuelDto> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
        {
            var fuel = _mapper.Map<Fuel>(request);
            // if (fuel == null)
            //     throw new NotFoundException(nameof(Fuel), request.Id);
            await _fuelRepository.DeleteAsync(fuel);
            var deletedFuelDto = _mapper.Map<DeletedFuelDto>(fuel);
            return deletedFuelDto;
        }
    }
}