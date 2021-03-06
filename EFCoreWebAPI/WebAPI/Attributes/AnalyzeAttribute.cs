﻿using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace WebAPI.Attributes
{
    public class AnalyzeAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logsService = context.HttpContext.RequestServices.GetService<ILogsService>();
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            LogDTO log = new LogDTO
            {
                ActionName = actionDescriptor.ActionName,
                ControllerName = actionDescriptor.ControllerName,
                ActionType = context.HttpContext.Request.Method,
                Date = DateTime.Now
            };

            await logsService.AddLogAsync(log);

            await next();
        }
    }
}
