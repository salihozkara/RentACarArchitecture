using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.DeleteModel;

public class DeleteModelCommand:IRequest<DeletedModelDto>
{
    public int Id { get; set; }
    // DeleteModelCommandHandler
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeletedModelDto>
    {
        private readonly IModelRepository _modelRepository;
        // Mapper
        private readonly IMapper _mapper;
        // ctor
        public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }
        public async Task<DeletedModelDto> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Model>(request);
            // if (model == null)
            //     throw new NotFoundException(nameof(Model), request.Id);
            await _modelRepository.DeleteAsync(model);
            var deletedModelDto = _mapper.Map<DeletedModelDto>(model);
            return deletedModelDto;
        }
    }
}