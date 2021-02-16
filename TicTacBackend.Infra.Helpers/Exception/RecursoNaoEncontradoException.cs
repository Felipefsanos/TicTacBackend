using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Infra.Helpers.Attribute;

namespace TicTacBackend.Infra.Helpers.Exception
{
    [HttpStatusCode(HttpStatusCode.NotFound)]
    public class RecursoNaoEncontradoException : ValidacaoException
    {
        public RecursoNaoEncontradoException()
        {
        }

        public RecursoNaoEncontradoException(string message) : base(message)
        {
        }

        public RecursoNaoEncontradoException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected RecursoNaoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
