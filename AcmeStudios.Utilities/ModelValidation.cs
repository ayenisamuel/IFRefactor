using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeStudios.Utilities
{
    public class ModelValidation: IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
     ActionExecutingContext context,
     ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .FirstOrDefault();
                context.Result = new BadRequestObjectResult(ServiceResponse<dynamic>.ErrorMessage(400, errors?? "Invalid request payload"));
                return;
            }

            await next();
        }
    }
}
