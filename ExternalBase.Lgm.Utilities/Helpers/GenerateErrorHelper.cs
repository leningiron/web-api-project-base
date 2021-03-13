using ExternalBase.Lgm.Utilities.Dto;
using System;
using System.Net;

namespace ExternalBase.Lgm.Utilities.Helpers
{
    public static class GenerateErrorHelper
    {
        public static ErrorDto SetError(int httpCode, string httpMessage, string developerMessage, string[] validationErrors)
        {
            return new ErrorDto
            {
                HttpCode = httpCode,
                HttpMessage = httpMessage,
                DeveloperMessage = developerMessage,
                ValidationErrors = validationErrors
            };
        }
        public static ErrorDto SetError(string httpMessages)
        {
            return new ErrorDto
            {
                HttpCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                HttpMessage = httpMessages
            };
        }
    }
}
