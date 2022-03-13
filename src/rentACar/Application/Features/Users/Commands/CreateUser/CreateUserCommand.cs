using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand:IRequest<User>
{
    public string Name { get; set; }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;
        // mail service
        private readonly IMailService _mailService;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, IMailService mailService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _mailService = mailService;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<User>(request);
            var createdUser= await _userRepository.AddAsync(mappedUser);
            
            // send email
            _mailService.Send(new Mail()
            {
                ToFullName = "system admins",
                ToEmail = "salihozkara00@gamil.com",
                Subject = "User Created",
                HtmlBody = $"User {request.Name} was created"
            });
            return createdUser;
        }
    }
   
}