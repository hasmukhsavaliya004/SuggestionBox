using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuggestionBox.Controllers
{
    public class SuggestionController : Controller
    {
        //
        // GET: /Suggestion/

        public ActionResult Index()
        {
            ViewBag.Success = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(Suggestion objSuggestion)
        {
            int returnVal = new SuggestionService().Add(objSuggestion);
            if (returnVal > 0)
                ViewBag.Success = "Thank you for sharing you suggestion.";
            else
                ViewBag.Success = "There is some error to add your suggestion, please try again.";
            return View();
        }

        [LoginFilterAttribute]
        public ActionResult ViewSuggestion()
        {
            List<Suggestion> model = new SuggestionService().GetAll();
            return View(model);
        }

        [LoginFilterAttribute]
        public ActionResult DeleteSuggestion(int id)
        {
            new SuggestionService().DeleteByID(id);
            return RedirectToAction("ViewSuggestion");
        }
        
    }
}
