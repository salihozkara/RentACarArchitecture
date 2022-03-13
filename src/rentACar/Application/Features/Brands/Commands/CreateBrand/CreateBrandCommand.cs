using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommand:IRequest<CreatedBrandDto>
{
    public string Name { get; set; }
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;
        // mail service
        private readonly IMailService _mailService;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules, IMailService mailService)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
            _mailService = mailService;
        }

        public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserting(request.Name);
            var mappedBrand = _mapper.Map<Brand>(request);
            await _brandRepository.AddAsync(mappedBrand);
            var createdBrandDto= _mapper.Map<CreatedBrandDto>(mappedBrand);
            
            // send email
            _mailService.Send(new Mail()
            {
                ToFullName = "system admins",
                ToEmail = "salihozkara00@gamil.com",
                Subject = "Brand Created",
                HtmlBody = $"Brand {request.Name} was created"
            });
            return createdBrandDto;
        }
    }
   
}