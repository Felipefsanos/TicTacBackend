using System.Net;
using System.Runtime.Serialization;
using TicTacBackend.Infra.Helpers.Attribute;

namespace TicTacBackend.Infra.Helpers.Exceptions
{
    [HttpStatusCode(HttpStatusCode.Conflict)]
    public class RecursoExistenteException : ValidacaoException
    {
        public RecursoExistenteException()
        {
        }

        public RecursoExistenteException(string message) : base(message)
        {
        }

        public RecursoExistenteException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected RecursoExistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
