namespace Core.Exceptions.UserExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string username) : 
            base($"Пользователь с именем - {username}, не найден!\nВведите другое имя.") { }

        public UserNotFoundException(int id) :
            base($"Пользователь с номером - {id}, не найден!\nВведите другой номер пользователя.")
        { }
    }
}
