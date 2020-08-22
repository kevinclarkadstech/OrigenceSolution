using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Origence.Models.Exceptions;
using System;

namespace Origence.Helpers
{
    public static class ExceptionsHelper
    {

        public static IActionResult HandleException(Exception ex)
        {
            if (ex is ValidationException validationException)
            {
                return new BadRequestObjectResult(new { errors = validationException.ValidationErrors });
            }
            else if (ex is BadInputException)
            {
                return new BadRequestResult();
            }
            else if (ex is EntityNotFoundException)
            {
                return new NotFoundResult();
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
