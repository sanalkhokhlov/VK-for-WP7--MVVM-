using System;
using System.Net;
using RestSharp;

namespace VkWP.Exceptions
{
    public class VkException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public RestResponseBase Response { get; private set; }

        public VkException()
        {
        }

        public VkException(string message)
            : base(message)
        {
        }

        public VkException(RestResponseBase response)
        {
            Response = response;
            StatusCode = response.StatusCode;
        }
    }
}
