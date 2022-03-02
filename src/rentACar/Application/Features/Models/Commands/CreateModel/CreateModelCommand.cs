using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.CreateModel;

public class CreateModelCommand:IRequest<Model>
{
    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public int BrandId { get; set; }
    public string ImageUrl { get; set; }
    
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, Model>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        private readonly ModelBusinessRules _modelBusinessRules;

        public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<Model> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            await _modelBusinessRules.ModelNameCanNotBeDuplicatedWhenInserting(request.Name);
            var mappedModel = _mapper.Map<Model>(request);
            var createdModel= await _modelRepository.AddAsync(mappedModel);
            return createdModel;
        }
    }
   
}