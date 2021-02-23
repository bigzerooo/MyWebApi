using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace WebAPI.Attributes
{
    public class AnalyzeAttribute: Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logsService = context.HttpContext.RequestServices.GetService<ILogsService>();
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            LogDTO log = new LogDTO
            {
                ActionName = actionDescriptor.ActionName,
                ControllerName = actionDescriptor.ControllerName,
                Date = DateTime.Now
            };
            await logsService.AddLogAsync(log);

            await next();
        }
    }
}
