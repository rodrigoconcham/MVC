using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;

namespace MvcApplication3.Controllers
{
    public class ProductosController : Controller
    {
        private northwindEntities db = new northwindEntities();

        //
        // GET: /Productos/

        public ActionResult Index(string criterio = null)
        {
           if (Request.IsAjaxRequest()) 
 
         {

             return PartialView("ProductoPartial",db.Products.Where(p => criterio == null || p.ProductName.StartsWith(criterio)).ToList());
         }
           return View(db.Products.Where(p => criterio == null || p.ProductName.StartsWith(criterio)).ToList());
        }

        //
        // GET: /Productos/Details/5

        public ActionResult Details(int id = 0)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //
        // GET: /Productos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Productos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        //
        // GET: /Productos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //
        // POST: /Productos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        //
        // GET: /Productos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //
        // POST: /Productos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}