using Application.Features.Transmissions.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.DeleteTransmission;

public class DeleteTransmissionCommand:IRequest<DeletedTransmissionDto>
{
    public int Id { get; set; }
    // DeleteTransmissionCommandHandler
    public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, DeletedTransmissionDto>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        // Mapper
        private readonly IMapper _mapper;
        // ctor
        public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }
        public async Task<DeletedTransmissionDto> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
        {
            var transmission = _mapper.Map<Transmission>(request);
            // if (transmission == null)
            //     throw new NotFoundException(nameof(Transmission), request.Id);
            await _transmissionRepository.DeleteAsync(transmission);
            var deletedTransmissionDto = _mapper.Map<DeletedTransmissionDto>(transmission);
            return deletedTransmissionDto;
        }
    }
}