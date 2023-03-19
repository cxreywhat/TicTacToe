using AutoMapper;
using Core.Dto.UserDto;
using Core.Exceptions.UserExceptions;
using Core.Models;
using Core.RegularExpressions;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Api.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthRegularExpressions authRegular;
        private readonly UserRegularExpressions userRegular;    
        public UserService(IUserRepository userRepository, IMapper mapper,
            IConfiguration configuration)
        { 
            _userRepository = userRepository; 
            _mapper = mapper;
            authRegular = new AuthRegularExpressions(configuration);
            userRegular = new UserRegularExpressions();
        }

        public async Task<User> Register(UserRegisterDto newUser)
        {
            userRegular.ValidNewUser(newUser);
            if (await _userRepository.UserExistsAsync(newUser.Username))
            {
                throw new UserExistsException();
            }

            authRegular.CreatePasswordHash(newUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = _mapper.Map<User>(newUser);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userRepository.CreateUserAsync(user);

            return user;
        }

        public async Task<string> Login(UserLoginDto logUser)
        {
            string token;
            var user = await _userRepository.GetUserByNameAsync(logUser.Username);

            if (user is null)
                throw new UserNotFoundException(logUser.Username);
            else if (!authRegular.VerifyPassword(logUser.Password, user.PasswordHash, user.PasswordSalt))
                throw new InvalidPasswordException("Введен не правильный пароль!");
            else
                token = authRegular.CreateToken(user);

            return token;
        }
    }
}
