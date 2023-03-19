namespace Core.Exceptions.GameException
{
    public class NotFoundGameException : Exception
    {
        public NotFoundGameException(int id) : 
            base($"Игра с номером '{id}' не найдена!")
        {
        }
    }
}
