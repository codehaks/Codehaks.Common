using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Codehaks.Common.Filters
{
    public class ValidateModelAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var ctrl = (Controller)context.Controller;

                var view = new ViewResult
                {
                    ViewName = context.RouteData.Values["Action"].ToString(),
                    ViewData = ctrl.ViewData
                };

                context.Result = view;
            }
        }
    }
}