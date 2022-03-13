using Application.Features.Colors.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.DeleteColor;

public class DeleteColorCommand:IRequest<DeletedColorDto>
{
    public int Id { get; set; }
    // DeleteColorCommandHandler
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeletedColorDto>
    {
        private readonly IColorRepository _colorRepository;
        // Mapper
        private readonly IMapper _mapper;
        // ctor
        public DeleteColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<DeletedColorDto> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            var color = _mapper.Map<Color>(request);
            // if (color == null)
            //     throw new NotFoundException(nameof(Color), request.Id);
            await _colorRepository.DeleteAsync(color);
            var deletedColorDto = _mapper.Map<DeletedColorDto>(color);
            return deletedColorDto;
        }
    }
}