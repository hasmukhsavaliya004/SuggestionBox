using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuggestionBox.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            Session["UserId"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            if (UserName == "Admin" && Password == "Admin@123")
            {
                Session["UserId"] = "1";
                return RedirectToAction("ViewSuggestion", "Suggestion");
            }
            else
            {
                ViewBag.Msg = "User name or password is wrong";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserId"] = null;
            return RedirectToAction("Login");
        }
        
    }
}
