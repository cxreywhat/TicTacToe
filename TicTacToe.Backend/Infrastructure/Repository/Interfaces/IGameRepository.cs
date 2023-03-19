using Core.Dto.GameDto;
using Core.Models;
using System.Xml.Linq;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGameRepository
    {
        public Task<Game?> GetGameByIdAsync(int gameId); 
        public Task CreateGameAsync(Game newGame);
        public Task UpdateGameAsync(int id, Game updGame);
    }
}
