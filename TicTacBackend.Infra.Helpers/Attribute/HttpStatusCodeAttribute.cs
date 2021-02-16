using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Infra.Helpers.Attribute
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    sealed class HttpStatusCodeAttribute : System.Attribute
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpStatusCodeAttribute(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
