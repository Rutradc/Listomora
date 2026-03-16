namespace Listomora.Application.Contracts.Persistence.CustomExceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string? message = "Invalid Credentials.") : base(message)
        {
        }
    }
}
