namespace Core.Exceptions.UserExceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException(string message) : base(message)
        {
        }
    }
}
