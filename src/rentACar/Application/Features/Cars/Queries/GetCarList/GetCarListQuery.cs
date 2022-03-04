using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetCarList;

public class GetCarListQuery:IRequest<CarListModel>
{
    // Page Request
    public PageRequest PageRequest { get; set; }
    
    public class GetCarListQueryHandler : IRequestHandler<GetCarListQuery, CarListModel>
    {
        private readonly ICarRepository _carRepository;
        // Mapper
        private readonly IMapper _mapper;

        public GetCarListQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarListModel> Handle(GetCarListQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetListAsync( include:
                c => c.Include(c => c.Model)
                    .Include(c => c.Model.Brand)
                    .Include(c => c.Color), index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken); 
            var car = _mapper.Map<CarListModel>(cars);
            return car;
        }
    }
}