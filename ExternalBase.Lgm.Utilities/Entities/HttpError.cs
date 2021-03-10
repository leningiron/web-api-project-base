using ExternalBase.Lgm.Utilities.Dto;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Net;

namespace ExternalBase.Lgm.Utilities.Entities
{
    public class HttpError : ErrorDto
    {
        public static HttpError CreateHttpValidationError(
            HttpStatusCode status,
            string userMessage,
            string[] validationErrors)
        {
            var httpError = CreateDefaultHttpError(status, userMessage);

            httpError.ValidationErrors = validationErrors;

            return httpError;
        }

        public static HttpError Create(
            IHostingEnvironment environment,
            HttpStatusCode status,
            string userMessage,
            string developerMessage)
        {
            var httpError = CreateDefaultHttpError(status, userMessage);

            httpError.HttpCode = Convert.ToInt32(status);

            if (environment.IsDevelopment())
            {
                httpError.DeveloperMessage = developerMessage;
            }

            return httpError;
        }

        private static HttpError CreateDefaultHttpError(
            HttpStatusCode status,
            string userMessage)
        {
            var httpError = new HttpError
            {
                HttpCode = Convert.ToInt32(status),
                HttpMessage = userMessage
            };

            return httpError;
        }
    }
}
