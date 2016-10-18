using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuggestionBox
{
    public class LoginFilterAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["UserId"])))
            {
                filterContext.Result = new System.Web.Mvc.RedirectResult("~/Account/Login");
            }
        }
    }
}