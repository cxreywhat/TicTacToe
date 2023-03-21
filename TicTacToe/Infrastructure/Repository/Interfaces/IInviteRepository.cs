using Core.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IInviteRepository
    {
        public Task<List<Invite>> GetAllUserCurrentInvites();
        public Task<Invite> GetInviteByGameIdAsync(int id);
        public Task CreateInviteAsync(Invite newInvite);
        public Task<Invite> UpdateInviteAsync(Invite updInvite);
    }
}
