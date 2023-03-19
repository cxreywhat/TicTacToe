using Core.Models;
using Core.Exceptions.GameException;

namespace Core.RegularExpressions
{
    public class GameRegularExpressions
    {
        public bool IsWinCombination(string field)
        {
            return field[0] == field[1] && field[1] == field[2] && field[0] != '0'
                || field[3] == field[4] && field[4] == field[5] && field[3] != '0'
                || field[6] == field[7] && field[7] == field[8] && field[6] != '0'
                || field[0] == field[3] && field[3] == field[6] && field[0] != '0'
                || field[1] == field[4] && field[4] == field[7] && field[1] != '0'
                || field[2] == field[5] && field[5] == field[8] && field[2] != '0'
                || field[0] == field[4] && field[4] == field[8] && field[0] != '0'
                || field[2] == field[4] && field[4] == field[6] && field[2] != '0' ? true : false;
        }

        public bool IsValidCellNumber(int numCell)
        {
            return numCell <= Constants.MAX_INPUT_CELL_VALUE
                || numCell >= Constants.MIN_INPUT_CELL_VALUE ? true : false;
        }

        public bool IsCurrentPlayerMove(int idCurrentPlayer, int idNeedPlayer, int steps)
        {
            return idCurrentPlayer == idNeedPlayer && steps % 2 != 0 ? true : false;
        }

        public bool IsZeroSteps(int steps)
        {
            return steps == 0 ? true : false;
        }
    }
}
