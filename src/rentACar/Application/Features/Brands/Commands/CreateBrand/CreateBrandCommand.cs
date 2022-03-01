using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommand:IRequest<Brand>
{
    public string Name { get; set; }
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Brand>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        

        public async Task<Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var mappedBrand = _mapper.Map<Brand>(request);
            var createdBrand= await _brandRepository.AddAsync(mappedBrand);
            return createdBrand;
        }
    }
   
}