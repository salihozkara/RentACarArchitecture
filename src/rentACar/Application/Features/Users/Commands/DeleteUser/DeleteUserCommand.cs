using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand:IRequest<User>
{
    public int Id { get; set; }
    // DeleteUserCommandHandler
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        // Mapper
        private readonly IMapper _mapper;
        // ctor
        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            // if (user == null)
            //     throw new NotFoundException(nameof(User), request.Id);
            await _userRepository.DeleteAsync(user);
            return user;
        }
    }
}