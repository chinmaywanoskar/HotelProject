using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using hotelproject.Areas.registration.Data;
using System.Diagnostics.SymbolStore;

namespace hotelproject.Areas.registration.Controllers
{
    public class registrationController : Controller
    {

        dbtEntities dt = new dbtEntities();

        // GET: registration/registration
        public ActionResult Index()
        {
            return View(dt.customers.ToList());
        }

        public ActionResult addcustomer()

        {

            return View();

        }

        [HttpPost]


        public ActionResult addcustomer(customer c)
        {

            dt.customers.Add(c);

            dt.SaveChanges();

            return RedirectToAction("Index","login");

        }

        public ActionResult deletecustomer(int id)
        {

           customer t = dt.customers.Find(id);

            dt.customers.Remove(t);

            dt.SaveChanges();

            return RedirectToAction("Index");




        }

        public ActionResult update(int id, string f, string l, long cn, string e, string p, int r)
        {

            customer c = new customer();

            c.cust_id = id;
            c.first_name = f;
            c.last_name = l;
            c.contactnumber = cn;
            c.email = e;

            c.password = p;
            c.role_id = r;
            return View(c);



        }

        [HttpPost]

        public ActionResult update(customer t)
        {

            dt.Entry(t).State = System.Data.Entity.EntityState.Modified;

            dt.SaveChanges();

            return RedirectToAction("Index");



        }

    }
}