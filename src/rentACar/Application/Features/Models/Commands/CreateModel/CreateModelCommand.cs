using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.CreateModel;

public class CreateModelCommand:IRequest<CreatedModelDto>
{
    public string Name { get; set; }
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelDto>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        private readonly ModelBusinessRules _modelBusinessRules;
        // mail service
        private readonly IMailService _mailService;

        public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules, IMailService mailService)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _modelBusinessRules = modelBusinessRules;
            _mailService = mailService;
        }

        public async Task<CreatedModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            await _modelBusinessRules.ModelNameCanNotBeDuplicatedWhenInserting(request.Name);
            var mappedModel = _mapper.Map<Model>(request);
            await _modelRepository.AddAsync(mappedModel);
            var createdModelDto= _mapper.Map<CreatedModelDto>(mappedModel);
            
            // send email
            _mailService.Send(new Mail()
            {
                ToFullName = "system admins",
                ToEmail = "salihozkara00@gamil.com",
                Subject = "Model Created",
                HtmlBody = $"Model {request.Name} was created"
            });
            return createdModelDto;
        }
    }
   
}