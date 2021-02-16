using System.Net;
using System.Runtime.Serialization;
using TicTacBackend.Infra.Helpers.Attribute;

namespace TicTacBackend.Infra.Helpers.Exceptions
{
    [HttpStatusCode(HttpStatusCode.Unauthorized)]
    public class NaoAutorizadoException : ValidacaoException
    {
        public NaoAutorizadoException()
        {
        }

        public NaoAutorizadoException(string message) : base(message)
        {
        }

        public NaoAutorizadoException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected NaoAutorizadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
