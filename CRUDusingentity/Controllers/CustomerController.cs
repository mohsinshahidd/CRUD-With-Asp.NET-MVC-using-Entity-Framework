using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDusingentity.Models;
using System.Data.Entity;

namespace CRUDusingentity.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (CRUDentityEntities dbmodel = new CRUDentityEntities())
            {
                return View(dbmodel.Customers.ToList());
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (CRUDentityEntities dbmodel = new CRUDentityEntities())
            {
                return View(dbmodel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                using (CRUDentityEntities dbmodel = new CRUDentityEntities())
                {
                    dbmodel.Customers.Add(customer);
                    dbmodel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (CRUDentityEntities dbmodel = new CRUDentityEntities())
            {
                return View(dbmodel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                    using (CRUDentityEntities dbmodel = new CRUDentityEntities())
                {
                    dbmodel.Entry(customer).State = EntityState.Modified;
                    dbmodel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (CRUDentityEntities dbmodel = new CRUDentityEntities())
            {
                return View(dbmodel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (CRUDentityEntities dbmodel = new CRUDentityEntities())
                {
                    Customer customer = dbmodel.Customers.Where(x => x.Id == id).FirstOrDefault();
                    dbmodel.Customers.Remove(customer);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

