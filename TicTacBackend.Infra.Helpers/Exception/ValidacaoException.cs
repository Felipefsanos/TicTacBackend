using System.Net;
using System.Runtime.Serialization;
using TicTacBackend.Infra.Helpers.Attribute;

namespace TicTacBackend.Infra.Helpers.Exception
{
    [HttpStatusCode(HttpStatusCode.BadRequest)]
    public class ValidacaoException : System.Exception
    {
        public ValidacaoException()
        {

        }

        public ValidacaoException(string message) : base(message)
        {
        }

        public ValidacaoException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
