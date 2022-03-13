using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.CreateTransmission;

public class CreateTransmissionCommand:IRequest<CreatedTransmissionDto>
{
    public string Name { get; set; }
    public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreatedTransmissionDto>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;
        private readonly TransmissionBusinessRules _transmissionBusinessRules;
        // mail service
        private readonly IMailService _mailService;

        public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusinessRules transmissionBusinessRules, IMailService mailService)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
            _transmissionBusinessRules = transmissionBusinessRules;
            _mailService = mailService;
        }

        public async Task<CreatedTransmissionDto> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
        {
            await _transmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserting(request.Name);
            var mappedTransmission = _mapper.Map<Transmission>(request);
            await _transmissionRepository.AddAsync(mappedTransmission);
            var createdTransmissionDto= _mapper.Map<CreatedTransmissionDto>(mappedTransmission);
            
            // send email
            _mailService.Send(new Mail()
            {
                ToFullName = "system admins",
                ToEmail = "salihozkara00@gamil.com",
                Subject = "Transmission Created",
                HtmlBody = $"Transmission {request.Name} was created"
            });
            return createdTransmissionDto;
        }
    }
   
}