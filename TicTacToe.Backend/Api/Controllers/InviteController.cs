using Api.Services;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Controller]
    [Authorize]
    [Route("[controller]")]
    public class InviteController : ControllerBase
    {
        private readonly InviteService _inviteService;
        public InviteController(InviteService inviteService)
        {
            _inviteService = inviteService;
        }

        [HttpGet("GetInvites")]
        public async Task<ActionResult<List<Invite>>> GetAllInvitesUser()
        {
            try
            {
                var response = await _inviteService.GetCurrentsInvites();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AcceptInvite")]
        public async Task<ActionResult<bool>> AcceptInvite(int gameId, bool isAcepted)
        {
            var response = await _inviteService.AcceptInvite(gameId, isAcepted);

            if(response == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
