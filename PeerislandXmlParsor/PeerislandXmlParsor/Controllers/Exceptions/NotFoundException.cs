using System;

namespace PeerislandXmlParsor.Controllers.Exceptions
{
    /// <summary>
    /// When thrown, this exception will direct the Controller to return NotFound as the Http response status
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
