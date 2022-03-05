using Application.Features.Transmissions.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using MediatR;

namespace Application.Features.Transmissions.Queries.GetTransmissionList;

public class GetTransmissionListQuery: IRequest<TransmissionListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetTransmissionListQueryHandler : IRequestHandler<GetTransmissionListQuery, TransmissionListModel>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public GetTransmissionListQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<TransmissionListModel> Handle(GetTransmissionListQuery request, CancellationToken cancellationToken)
        {
            var transmissions = await _transmissionRepository.GetListAsync(index:request.PageRequest.Page, size:request.PageRequest.PageSize, cancellationToken: cancellationToken);

            var mappedTransmissions = _mapper.Map<TransmissionListModel>(transmissions);
            return mappedTransmissions;
        }
    }
}