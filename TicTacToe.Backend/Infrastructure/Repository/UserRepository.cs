using Core.Dto.UserDto;
using Core.Exceptions.UserExceptions;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            if (await _dataContext.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
                return true;

            return false;
        }

        public async Task<User?> GetUserByNameAsync(string username) =>
            await _dataContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        public async Task<User?> GetUserByIdAsync(int id) =>
            await _dataContext.Users.FindAsync(id);
        public User? GetCurentUser() =>
            (User?)_httpContextAccessor.HttpContext.Items["User"];

        public async Task AddInvite(Invite invite, int userId)
        {
            var user = await _dataContext.Users.FindAsync(userId);

            if(user == null)
            {
                throw new UserNotFoundException(userId);
            }

            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
        }
        public async Task CreateUserAsync(User newUser)
        {
            if(newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            _dataContext.Users.Add(newUser);
            await _dataContext.SaveChangesAsync();

        }

        public async Task UpdateUserAsync(User newUser)
        {
            _dataContext.Users.Update(newUser);
            await _dataContext.SaveChangesAsync();
        }
    }
}
