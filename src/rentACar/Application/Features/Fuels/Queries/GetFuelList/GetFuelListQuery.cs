using Application.Features.Fuels.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using MediatR;

namespace Application.Features.Fuels.Queries.GetFuelList;

public class GetFuelListQuery: IRequest<FuelListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetFuelListQueryHandler : IRequestHandler<GetFuelListQuery, FuelListModel>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public GetFuelListQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<FuelListModel> Handle(GetFuelListQuery request, CancellationToken cancellationToken)
        {
            var fuels = await _fuelRepository.GetListAsync(index:request.PageRequest.Page, size:request.PageRequest.PageSize, cancellationToken: cancellationToken);

            var mappedFuels = _mapper.Map<FuelListModel>(fuels);
            return mappedFuels;
        }
    }
}