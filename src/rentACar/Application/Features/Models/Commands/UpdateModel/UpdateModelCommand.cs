using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.UpdateModel;

public class UpdateModelCommand : IRequest<UpdatedModelDto>
{
    // Domain.Entities.Model Properties
    public int Id { get; set; }
    public string Name { get; set; }

    // Handlers
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdatedModelDto>
    {
        // Model Repository
        private readonly IModelRepository _modelRepository;

        // Mapper
        private readonly IMapper _mapper;

        // Ctor
        public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        // Handle
        public async Task<UpdatedModelDto> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Model>(request);
            if (model == null)
            {
                throw new Exception("Model not found");
            }

            await _modelRepository.UpdateAsync(model);
            var updatedModelDto = _mapper.Map<UpdatedModelDto>(model);
            return updatedModelDto;
        }
    }
}