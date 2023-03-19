using Api.Services;
using AutoMapper.Internal;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Api.Controllers
{
    [Controller]
    [Authorize]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;
        private readonly InviteService _inviteService;
        public GameController(GameService gameService, InviteService inviteService)
        {
            _gameService = gameService;
            _inviteService = inviteService;
        }

        [HttpPut("Play")]
        public async Task<ActionResult<Game>> DoStep(int gameId, int numCell)
        {
            try
            {
                var game = await _gameService.DoStep(gameId, numCell);

                return Ok(game);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<object>> CreateNewGame(int friendId)
        {
            try
            {
                var game = await _gameService.CreateNewGame(friendId);
                var invite = await _inviteService.SendInvite(game);

                if (invite == null)
                {
                    return BadRequest(invite);
                }

                return Ok(game);
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
