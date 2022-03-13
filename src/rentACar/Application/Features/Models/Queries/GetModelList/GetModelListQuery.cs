using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using MediatR;

namespace Application.Features.Models.Queries.GetModelList;

public class GetModelListQuery: IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetModelListQueryHandler : IRequestHandler<GetModelListQuery, ModelListModel>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetModelListQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<ModelListModel> Handle(GetModelListQuery request, CancellationToken cancellationToken)
        {
            var models = await _modelRepository.GetListAsync(index:request.PageRequest.Page, size:request.PageRequest.PageSize, cancellationToken: cancellationToken);

            var mappedModels = _mapper.Map<ModelListModel>(models);
            return mappedModels;
        }
    }
}