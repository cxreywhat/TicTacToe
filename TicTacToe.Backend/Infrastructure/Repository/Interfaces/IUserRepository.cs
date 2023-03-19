using Core.Dto.UserDto;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByNameAsync(string username);
        public Task<User?> GetUserByIdAsync(int id);
        public User? GetCurentUser();
        public Task<bool> UserExistsAsync(string username);
        public Task AddInvite(Invite invite, int userId);
        public Task CreateUserAsync(User user);
        public Task UpdateUserAsync(User newUser);
    }
}
