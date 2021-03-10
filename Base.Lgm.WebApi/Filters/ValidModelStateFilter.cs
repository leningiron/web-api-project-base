using ExternalBase.Lgm.Utilities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Base.Lgm.WebApi.Filters
{
    public class ValidModelStateFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var validationErrors = context.ModelState
                .Keys
                .SelectMany(k => context.ModelState[k].Errors)
                .Select(e => e.ErrorMessage)
                .ToArray();

            var error = HttpError.CreateHttpValidationError(
                status: HttpStatusCode.BadRequest,
                userMessage: "There are validation errors",
                validationErrors: validationErrors);

            context.Result = new BadRequestObjectResult(error);
        }

    }
}
