using System;

namespace OpenInvoicePeru.Comun.Dto.Exceptions
{
    public class NoExisteCpeException : ApplicationException
    {
        public NoExisteCpeException()
        {
        }

        public NoExisteCpeException(string message) : base(message)
        {

        }

        public NoExisteCpeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}