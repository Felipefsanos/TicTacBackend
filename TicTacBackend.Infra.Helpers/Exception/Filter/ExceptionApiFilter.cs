using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Infra.Helpers.Attribute;

namespace TicTacBackend.Infra.Helpers.Exception.Filter
{
    public class ExceptionApiFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            HttpStatusCode statusCode = ObterStatusCode(exception);

            context.Result = CriarResultadoErro(statusCode, exception);
        }

        private HttpStatusCode ObterStatusCode(System.Exception exception)
        {
            var statusCodeAttribute = exception.GetType().GetCustomAttributes(typeof(HttpStatusCodeAttribute), true).FirstOrDefault();

            if (statusCodeAttribute is null)
                return HttpStatusCode.InternalServerError;

            return (statusCodeAttribute as HttpStatusCodeAttribute).StatusCode;
        }

        private ObjectResult CriarResultadoErro(HttpStatusCode statusCode, System.Exception exception)
        {
            if(statusCode == HttpStatusCode.InternalServerError)
            {
                return new ObjectResult(new RetornoErro(exception.Message, exception.StackTrace))
                {
                    StatusCode = (int)statusCode
                };
            }

            return new ObjectResult(new RetornoValidacao(exception.Message)) { StatusCode = (int)statusCode };
        }

        public class RetornoValidacao
        {
            public string Message { get; set; }
            public RetornoValidacao(string message)
            {
                Message = message;
            }
        }

        public class RetornoErro : RetornoValidacao
        {
            public string StackTrace { get; set; }
            public RetornoErro(string message, string stackTrace) : base(message)
            {
                StackTrace = stackTrace;
            }
        }
    }
}
