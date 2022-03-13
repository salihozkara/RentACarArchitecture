using Application.Features.Transmissions.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.UpdateTransmission;

public class UpdateTransmissionCommand : IRequest<UpdatedTransmissionDto>
{
    // Domain.Entities.Transmission Properties
    public int Id { get; set; }
    public string Name { get; set; }

    // Handlers
    public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, UpdatedTransmissionDto>
    {
        // Transmission Repository
        private readonly ITransmissionRepository _transmissionRepository;

        // Mapper
        private readonly IMapper _mapper;

        // Ctor
        public UpdateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        // Handle
        public async Task<UpdatedTransmissionDto> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
        {
            var transmission = _mapper.Map<Transmission>(request);
            if (transmission == null)
            {
                throw new Exception("Transmission not found");
            }

            await _transmissionRepository.UpdateAsync(transmission);
            var updatedTransmissionDto = _mapper.Map<UpdatedTransmissionDto>(transmission);
            return updatedTransmissionDto;
        }
    }
}