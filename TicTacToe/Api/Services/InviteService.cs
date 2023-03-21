using Core;
using Core.Exceptions.GameException;
using Core.Models;
using Infrastructure.Repository.Interfaces;
using System.Reflection.Metadata;

namespace Api.Services
{
    public class InviteService
    {
        public readonly IInviteRepository _inviteRepository;
        public readonly IUserRepository _userRepository;

        public InviteService(IInviteRepository inviteRepository, IUserRepository userRepository)
        {
            _inviteRepository = inviteRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Invite>> GetCurrentsInvites()
        {
            var invites = await _inviteRepository.GetAllUserCurrentInvites();

            if(invites == null)
            {
                throw new Exception("No invites");
            }

            return invites;
        }

        public async Task<Invite> SendInvite(Game game)
        {
            if(game == null)
            {
                throw new NotFoundGameException(game.Id);
            }
            var invite = new Invite()
            {
                FromUserId = game.IdFirstPlayer,
                GameId = game.Id,
                Status = Constants.INVITE_STATUS_WAITING,
                UserId = game.IdSecondPlayer,
                User = await _userRepository.GetUserByIdAsync(game.IdFirstPlayer),
            };

            await _inviteRepository.CreateInviteAsync(invite);
            return invite;
        }

        public async Task<Invite?> AcceptInvite(int gameId, bool isAccepted)
        { 
            var invite = await _inviteRepository.GetInviteByGameIdAsync(gameId);

            if(invite == null)
            {
                return null;
            }

            if(!isAccepted)
            {
                invite.Status = Constants.INVITE_STATUS_NOT_ACCEPTED;
            } 
            else
            {
                invite.Status = Constants.INVITE_STATUS_ACCEPTERD;
            }

            await _inviteRepository.UpdateInviteAsync(invite);
            return invite;
        }
    }
}
