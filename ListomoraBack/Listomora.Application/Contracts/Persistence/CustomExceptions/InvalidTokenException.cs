namespace Listomora.Application.Contracts.Persistence.CustomExceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(string? message = "Invalid token.") : base(message)
        {
        }
    }
}
