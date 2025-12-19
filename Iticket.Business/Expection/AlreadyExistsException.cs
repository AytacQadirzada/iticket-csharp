namespace Iticket.Business.Expection
{
    [Serializable]
    internal class AlreadyExistsException : Exception
    {
        public AlreadyExistsException()
        {
        }

        public AlreadyExistsException(string? message) : base(message)
        {
        }

        public AlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}