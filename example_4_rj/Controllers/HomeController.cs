using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using example_4_rj.DomainObjects;
using example_4_rj.Models;

namespace example_4_rj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Search(SearchModel searchQuery)
        {
            List<NaturalModel> nm = new List<NaturalModel>();
            List<ObitModel> om = new List<ObitModel>();
            List<CensusModel> cm = new List<CensusModel>();
            using (SearchADO db = new SearchADO())
            {
                using (var x = db.Database.BeginTransaction())
                {
                    List<Census> c = db.C.Where(cen => cen.First.ToLower().Contains(searchQuery.First.ToLower()) || cen.Last.ToLower().Contains(searchQuery.Last.ToLower()))
                        .ToList();                   
                    List<Naturals> n = db.N.Where(cen => cen.First.ToLower().Contains(searchQuery.First.ToLower()) || cen.Last.ToLower().Contains(searchQuery.Last.ToLower()))
                        .ToList();
                    List<Obit> o = db.O.Where(cen => cen.First.ToLower().Contains(searchQuery.First.ToLower()) || cen.Last.ToLower().Contains(searchQuery.Last.ToLower()))
                        .ToList();
                    foreach (var n_x in n)
                    {
                        nm.Add(new NaturalModel() { First = n_x.First, Last = n_x.Last });
                    }
                    foreach (var c_x in c)
                    {
                        cm.Add(new CensusModel { First = c_x.First, Last = c_x.Last });
                    }
                    foreach (var o_x in o)
                    {
                        om.Add(new ObitModel() {First = o_x.First, Last = o_x.Last});
                    }
                }
            }
            SearchContainerModel scm = new SearchContainerModel(om, cm, nm);
            return View(scm);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}