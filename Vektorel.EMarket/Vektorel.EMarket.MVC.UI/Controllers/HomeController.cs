using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vektorel.EMarket.MVC.UI.Controllers
{
    public class HomeController : Controller
    {

        //private readonly IUserRepository repo;
        //public HomeController(IUserRepository r)
        //{
        //    repo = r;
        //}


        // GET: Home
        public ActionResult Vektorel()
        {
            
            return View(viewName: "~/Views/Home/deneme.cshtml");
        }
        public string Index()
        {
            return "Index Action çalıştı";
        }
    }
}