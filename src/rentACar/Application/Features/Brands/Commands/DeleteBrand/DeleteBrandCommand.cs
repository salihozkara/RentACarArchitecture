using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommand:IRequest<DeletedBrandDto>
{
    public int Id { get; set; }
    // DeleteBrandCommandHandler
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        // Mapper
        private readonly IMapper _mapper;
        // ctor
        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<DeletedBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request);
            // if (brand == null)
            //     throw new NotFoundException(nameof(Brand), request.Id);
            await _brandRepository.DeleteAsync(brand);
            var deletedBrandDto = _mapper.Map<DeletedBrandDto>(brand);
            return deletedBrandDto;
        }
    }
}