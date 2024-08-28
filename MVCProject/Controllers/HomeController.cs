using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ContentResult contentResult = new ContentResult();
            //contentResult.Content = "Hello From Content Result !";
            return View();
            //return Content("Hello From Content Result !");
        }
        public ActionResult AboutUs()
        {
            //return Redirect("https://drive.google.com/drive/folders/18B9-kvGFWuqql0Ai_iRunjecAYvr4F-G?lfhs=2");
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
    }
}
