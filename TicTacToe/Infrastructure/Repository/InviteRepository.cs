using Core.Exceptions.InviteException;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repository
{
    public class InviteRepository : IInviteRepository
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContext;

        public InviteRepository(DataContext dataContext, IHttpContextAccessor httpContext)
        {
            _dataContext = dataContext;
            _httpContext = httpContext;
        }
        public async Task<List<Invite>> GetAllUserCurrentInvites()
        {
            var user = (User)_httpContext.HttpContext.Items["User"];
            if(user == null)
            {
                throw new Exception("Авторизуйтесь");
            }

            var invites = await _dataContext.Invites
                .Where(x =>
                    x.User.Id == user.Id && 
                    x.Status == "Waiting")
                .ToListAsync();

            if(invites == null)
            {
                throw new NotFoundInvitesException("No invites");
            }

            return invites;
        }

        public async Task<Invite> GetInviteByGameIdAsync(int id)
        {
            var invite = await _dataContext.Invites.FirstOrDefaultAsync(i =>
                i.GameId == id);

            if(invite == null)
            {
                throw new NotFoundInvitesException("Invite not found");
            }

            return invite;
        }

        public async Task CreateInviteAsync(Invite newInvite)
        {
            if(newInvite == null)
            {
                throw new Exception();
            }

            _dataContext.Invites.Add(newInvite);
            await _dataContext.SaveChangesAsync();
        }


        public async Task<Invite> UpdateInviteAsync(Invite updInvite)
        {
            if(updInvite == null)
            {
                throw new Exception();
            }

            _dataContext.Invites.Update(updInvite);
            await _dataContext.SaveChangesAsync();

            return updInvite;
        }
    }
}
