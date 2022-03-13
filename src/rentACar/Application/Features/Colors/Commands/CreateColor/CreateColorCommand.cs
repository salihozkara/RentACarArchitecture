using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.CreateColor;

public class CreateColorCommand:IRequest<CreatedColorDto>
{
    public string Name { get; set; }
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreatedColorDto>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        private readonly ColorBusinessRules _colorBusinessRules;
        // mail service
        private readonly IMailService _mailService;

        public CreateColorCommandHandler(IColorRepository colorRepository, IMapper mapper, ColorBusinessRules colorBusinessRules, IMailService mailService)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
            _colorBusinessRules = colorBusinessRules;
            _mailService = mailService;
        }

        public async Task<CreatedColorDto> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            await _colorBusinessRules.ColorNameCanNotBeDuplicatedWhenInserting(request.Name);
            var mappedColor = _mapper.Map<Color>(request);
            await _colorRepository.AddAsync(mappedColor);
            var createdColorDto= _mapper.Map<CreatedColorDto>(mappedColor);
            
            // send email
            _mailService.Send(new Mail()
            {
                ToFullName = "system admins",
                ToEmail = "salihozkara00@gamil.com",
                Subject = "Color Created",
                HtmlBody = $"Color {request.Name} was created"
            });
            return createdColorDto;
        }
    }
   
}