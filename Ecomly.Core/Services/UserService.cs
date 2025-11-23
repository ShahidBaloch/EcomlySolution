using AutoMapper;
using Ecomly.Core.DTOs;
using Ecomly.Core.Entities;
using Ecomly.Core.RepositoryContracts;
using Ecomly.Core.ServiceContracts;

namespace Ecomly.Core.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository,IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user == null)
        {
            return null;
        }
        //return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "Token", Success: true);
        return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token"};

    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //ApplicationUser user = new ApplicationUser()
        //{
        //    PersonName = registerRequest.PersonName,
        //    Email = registerRequest.Email,
        //    Password = registerRequest.Password,
        //    Gender = registerRequest.Gender.ToString(),
        //};
        ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
        ApplicationUser? registeredUser = await _userRepository.AddUser(user);
        if (registeredUser == null)
        {
            return null;
        }
        //return new AuthenticationResponse(registerUser.UserID, registerUser.Email, registerUser.PersonName, registerUser.Gender, "token", Success: true);
        return _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };
    }
}
