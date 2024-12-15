


namespace OceanaAura.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) {}
        public List<string> ErrorMessages { get; }

        // Constructor accepting a list of error messages
        public BadRequestException(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
