using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.DeleteTransmission;

public class DeleteTransmissionCommand:IRequest<Transmission>
{
    public int Id { get; set; }
    // DeleteTransmissionCommandHandler
    public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, Transmission>
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
        public async Task<Transmission> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
        {
            var transmission = _mapper.Map<Transmission>(request);
            // if (transmission == null)
            //     throw new NotFoundException(nameof(Transmission), request.Id);
            await _transmissionRepository.DeleteAsync(transmission);
            return transmission;
        }
    }
}