using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AcmeStudios.Utilities
{
    public class ExceptionFilters: ExceptionFilterAttribute
    {
        private Audit<ExceptionFilters> _audit;
        public ExceptionFilters(Audit<ExceptionFilters> audit)
        {
            _audit = audit;
        }
        public override void OnException(ExceptionContext context)
        {
            var tokenError = context.Exception.Message.Contains("token_not_valid");
            var exception = context.Exception;
            _audit.LogFatal(exception);
            //log your exception here
            var result = tokenError ? new ObjectResult(ServiceResponse<dynamic>.TokenMessage()) : new ObjectResult(ServiceResponse<dynamic>.SystemError());
            result.StatusCode = tokenError ? (int)HttpStatusCode.Unauthorized : (int)HttpStatusCode.InternalServerError;
            context.Result = result;
            context.ExceptionHandled = true; //optional 
        }
    }
}
