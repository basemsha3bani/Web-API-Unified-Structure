using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using LinkedInWebAPI.Controllers;

internal class ValidationFilterAttribute : IActionFilter
{
    IConfiguration _configuration;
    public ValidationFilterAttribute(IConfiguration configuration )
    {
        _configuration = configuration;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        AuthenticationInfo authenticationInfo = (AuthenticationInfo)context.ActionArguments["authenticationInfo"];
        if (authenticationInfo.Token != _configuration.GetSection("LinkedInCredentials").GetSection("Token").Value )
        {
            context.Result = new UnauthorizedResult();
            return;
        }

       
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
