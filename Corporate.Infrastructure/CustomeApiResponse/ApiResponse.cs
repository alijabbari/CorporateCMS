using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Corporate.Infrastructure.CustomeApiRespone
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        public string Message { get; set; }
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultmessageForStatusCode(statusCode);
        }
        private static string GetDefaultmessageForStatusCode(int statusCode) => statusCode switch
        {
            200=>"Success",
            400 => "A bad request, you have made",
            401 => "Authorized, you are not",
            404 => "Resource found, it was not",
            500 => "Errors are the path to the dark side. Errors lead to anger.  Anger leads to hate.  Hate leads to career change",
            _ => null,
        };
    }
}
