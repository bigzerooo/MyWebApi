//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebAPI.Attributes
//{
//    public class ValidateModelAttribute : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            if (actionContext.ModelState.IsValid == false)
//            {
//                actionContext.Response = actionContext.Request.CreateErrorResponse(
//                    HttpStatusCode.BadRequest, actionContext.ModelState);
//            }
//        }
//    }
//}
