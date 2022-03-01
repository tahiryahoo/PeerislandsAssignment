using System;

namespace PeerislandXmlParsor.Controllers.Exceptions
{
    /// <summary>
    /// When thrown, this exception will direct the Controller to return BadRequest as the Http response status
    /// </summary>
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {

        }
        public BadRequestException(string message) : base(message)
        {

        }
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
