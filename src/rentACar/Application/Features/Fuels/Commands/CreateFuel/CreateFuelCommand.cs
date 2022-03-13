using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.CreateFuel;

public class CreateFuelCommand:IRequest<CreatedFuelDto>
{
    public string Name { get; set; }
    public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, CreatedFuelDto>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;
        private readonly FuelBusinessRules _fuelBusinessRules;
        // mail service
        private readonly IMailService _mailService;

        public CreateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules, IMailService mailService)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
            _fuelBusinessRules = fuelBusinessRules;
            _mailService = mailService;
        }

        public async Task<CreatedFuelDto> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
        {
            await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInserting(request.Name);
            var mappedFuel = _mapper.Map<Fuel>(request);
            await _fuelRepository.AddAsync(mappedFuel);
            var createdFuelDto= _mapper.Map<CreatedFuelDto>(mappedFuel);
            
            // send email
            _mailService.Send(new Mail()
            {
                ToFullName = "system admins",
                ToEmail = "salihozkara00@gamil.com",
                Subject = "Fuel Created",
                HtmlBody = $"Fuel {request.Name} was created"
            });
            return createdFuelDto;
        }
    }
   
}