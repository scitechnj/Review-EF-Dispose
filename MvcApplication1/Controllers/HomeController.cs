using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MvcApplication1.Controllers
{
    public class PeopleViewModel
    {
        public IEnumerable<Person> Persons { get; set; } 
    }

    public class HomeController : Controller
    {
        private MyDataLayer _layer = new MyDataLayer();

        public ActionResult Index()
        {
            return View(new PeopleViewModel{Persons = _layer.GetPersons()});
        }

        protected override void Dispose(bool disposing)
        {
            _layer.Dispose();
            base.Dispose(disposing);
        }

    }
}
