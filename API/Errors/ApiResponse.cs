using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

       
        public int StatusCode { get; set; }
        public string Message { get; set; }

         private string GetDefaultMessageForStatusCode(int statusCode)
        {
             return statusCode switch
            {
                400 => "You have made, a bad request,",
                401 => "You are not Authorized",
                403 => "You are forbidden to access this resource",
                404 => "Resource was not found",
                500 => "Application or Server Side error.",
                _ => null
            };
        }
    }
}