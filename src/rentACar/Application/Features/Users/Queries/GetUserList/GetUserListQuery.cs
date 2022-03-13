using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using MediatR;

namespace Application.Features.Users.Queries.GetUserList;

public class GetUserListQuery: IRequest<UserListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserListModel> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetListAsync(index:request.PageRequest.Page, size:request.PageRequest.PageSize, cancellationToken: cancellationToken);

            var mappedUsers = _mapper.Map<UserListModel>(users);
            return mappedUsers;
        }
    }
}