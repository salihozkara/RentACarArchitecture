using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.UpdateColor;

public class UpdateColorCommand : IRequest<Color>
{
    // Domain.Entities.Color Properties
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Handlers
    public class UpdateColorCommandHandler:IRequestHandler<UpdateColorCommand,Color>
    {
        // Color Repository
        private readonly IColorRepository _colorRepository;
        // Mapper
        private readonly IMapper _mapper;
        // Ctor
        public UpdateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        // Handle
        public async Task<Color> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            var color = _mapper.Map<Color>(request);
            if (color == null)
            {
                throw new Exception("Color not found");
            }
            await _colorRepository.UpdateAsync(color);
            return color;
        }
    }
}