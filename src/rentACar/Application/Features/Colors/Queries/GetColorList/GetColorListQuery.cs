using Application.Features.Colors.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using MediatR;

namespace Application.Features.Colors.Queries.GetColorList;

public class GetColorListQuery: IRequest<ColorListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetColorListQueryHandler : IRequestHandler<GetColorListQuery, ColorListModel>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetColorListQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<ColorListModel> Handle(GetColorListQuery request, CancellationToken cancellationToken)
        {
            var colors = await _colorRepository.GetListAsync(index:request.PageRequest.Page, size:request.PageRequest.PageSize, cancellationToken: cancellationToken);

            var mappedColors = _mapper.Map<ColorListModel>(colors);
            return mappedColors;
        }
    }
}