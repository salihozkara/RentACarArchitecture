using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommand : IRequest<Brand>
{
    // Domain.Entities.Brand Properties
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Handlers
    public class UpdateBrandCommandHandler:IRequestHandler<UpdateBrandCommand,Brand>
    {
        // Brand Repository
        private readonly IBrandRepository _brandRepository;
        // Mapper
        private readonly IMapper _mapper;
        // Ctor
        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        // Handle
        public async Task<Brand> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request);
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }
            await _brandRepository.UpdateAsync(brand);
            return brand;
        }
    }
}