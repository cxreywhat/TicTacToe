using System;
using Core;
using Core.Exceptions.GameException;
using Core.Exceptions.UserExceptions;
using Core.Models;
using Core.RegularExpressions;
using Infrastructure.Repository.Interfaces;

namespace Api.Services
{
    public class GameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;
        private readonly GameRegularExpressions regular;

        public GameService(IGameRepository gameRepository, IUserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            regular = new GameRegularExpressions();
        }



        public async Task<Game?> CreateNewGame(int friendId)
        {
            var friend = await _userRepository.GetUserByIdAsync(friendId);
            var user = _userRepository.GetCurentUser();
            if(friend == null)
            {
                throw new UserNotFoundException(friendId);
            }
            if(user == null)
            {
                throw new Exception("Масленок починика конвейер или что с ним связано.");
            }

            var game = new Game()
            {
                IdFirstPlayer = user.Id,
                IdSecondPlayer = friend.Id,
                Field = new int[9],
                Steps = 9,
                Status = Constants.GAME_STATUS_PENDING,
            };

            await _gameRepository.CreateGameAsync(game);

            return game;
        }

        public async Task<Game?> DoStep(int gameId, int numCell)
        {
            var game = await _gameRepository.GetGameByIdAsync(gameId);
            var player = _userRepository.GetCurentUser();

            if (game == null)
                throw new NotFoundGameException(gameId);
            else if (player == null)
                throw new Exception("Реально пофикси уже конвейер сколько можно");
            else if (game.Status != Constants.GAME_STATUS_STARTED)
                throw new InvalidStatusGameException(game.Status, Constants.GAME_STATUS_STARTED);
            else if (!regular.IsValidCellNumber(numCell))
                throw new InvalidCellNumberException($"Номер клетки должен быть от 0 до 8");
            else if (game.Field[numCell] != '0')
                throw new InvalidCellNumberException(numCell);

            if (regular.IsCurrentPlayerMove(player.Id, game.IdFirstPlayer, game.Steps))
            {
                SetSign(numCell, ref game, Constants.CROSS);
            }
            else
            {
                SetSign(numCell, ref game, Constants.ZERO);
            }

            if (regular.IsWinCombination(game.Field))
            {
                game.Status = Constants.GAME_STATUS_FINISHED;
                game.Winner = player.Username;
            } 
            else if (regular.IsZeroSteps(game.Steps))
            {
                game.Status = Constants.GAME_STATUS_FINISHED;
                game.Winner = "Draw";
            }

            await _gameRepository.UpdateGameAsync(game.Id, game);

            return game;
        }

        private void SetSign(int numCell, ref Game game, int sign)
        {
            game.Field[numCell] = sign;
            game.Steps--;
        }
    }
}
