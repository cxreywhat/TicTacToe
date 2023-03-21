namespace Core.Exceptions.GameException
{
    public class InvalidStatusGameException : Exception
    {
        public InvalidStatusGameException(string curentGameStatus, string needGameStatus) :
            base($"Статус игры должен быть - {needGameStatus}. Текущий статус игры - {curentGameStatus}")
        {
        }
    }
}
