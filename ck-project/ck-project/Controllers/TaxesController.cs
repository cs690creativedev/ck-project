using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ck_project.Controllers
{
    public class TaxesController : Controller
    {
        // GET: Taxes
        //connecting db
        ckdatabase db = new ckdatabase();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddTax()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTax(FormCollection form)
        {
            
            tax target = new tax();
            //get property
            TryUpdateModel(target, new string[] { "tax_anme", "tax_value", "city", "state", "county", "zipcode", "start_date", "end_date" }, form.ToValueProvider());
            //validate
            if (string.IsNullOrEmpty(target.tax_anme))
                ModelState.AddModelError("tax_anme", "Tax Type is required");

            if (ModelState.IsValid)
            {
               
                db.taxes.Add(target);
                db.SaveChanges();
            }

            return View(target);
        }



        public ActionResult SearchTax()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ActionName("SearchTax")]
        public ActionResult ViewTax(FormCollection fo)
        {
            string strName = fo["zipcode"].ToString();
            List<tax> TaxList = db.taxes.Where(d => d.zipcode == strName).ToList();
            ViewBag.TaxList = TaxList;
            
            return View("ViewTax");

        }

       
    }
}