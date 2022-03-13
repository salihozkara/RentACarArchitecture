using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<User>
{
    // Domain.Entities.User Properties
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Handlers
    public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,User>
    {
        // User Repository
        private readonly IUserRepository _userRepository;
        // Mapper
        private readonly IMapper _mapper;
        // Ctor
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        // Handle
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            await _userRepository.UpdateAsync(user);
            return user;
        }
    }
}