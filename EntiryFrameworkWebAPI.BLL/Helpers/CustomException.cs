using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EntiryFrameworkWebAPI.BLL.Helpers
{
    public class CustomeException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public CustomeException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomeException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public CustomeException(string message) : this(HttpStatusCode.InternalServerError, message)
        {
        }

        public CustomeException(string message, Exception innerException) : this(HttpStatusCode.InternalServerError, message, innerException)
        {
        }
    }
}
