namespace Core.Exceptions.UserExceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException() : base("Данный пользователь уже существует")
        {
        }
    }
}
