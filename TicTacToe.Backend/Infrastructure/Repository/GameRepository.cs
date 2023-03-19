using Core.Models;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;


namespace Infrastructure.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _dataContext;

        public GameRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Game?> GetGameByIdAsync(int gameId)
        {
            var game = await _dataContext.Games.FindAsync(gameId);

            if(game == null)
            {
                throw new Exception();
            }

            return game;
        }
        public async Task CreateGameAsync(Game newGame)
        {
            if (newGame == null)
            {
                throw new Exception();
            }

            _dataContext.Games.Add(newGame);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(int id, Game updGame)
        {
            if (updGame == null)
            {
                throw new Exception();
            }

            _dataContext.Games.Update(updGame);
            await _dataContext.SaveChangesAsync();
        }
    }
}
