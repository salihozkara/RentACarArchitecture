using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Users.Rules;

public class UserBusinessRules
{ 
    private readonly IUserRepository _userRepository;
    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public void CheckUserExists(int id)
    {
        var user = _userRepository.GetAsync(u=>u.Id==id);
        if (user == null)
        {
            throw new BusinessException("User not found");
        }
    }
}