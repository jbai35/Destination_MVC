using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Destination_MVC.Models;

namespace Destination_MVC.Controllers
{
    public class Order_detailsController : Controller
    {
        private TraverEntities db = new TraverEntities();

        // GET: Order_details
        public ActionResult Index()
        {
            var order_details = db.Order_details.Include(o => o.User_details);
            return View(order_details.OrderBy(o => o.departureDate).ToList());
        }

        // GET: Order_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_details order_details = db.Order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            return View(order_details);
        }

        // GET: Order_details/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.User_details, "userId", "username");
            return View();
        }

        // POST: Order_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderId,userId,orderInfo,fromCity,toCity,departureDate,returnDate,peopleNumber,payment")] Order_details order_details)
        {
            if (ModelState.IsValid)
            {
                db.Order_details.Add(order_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.User_details, "userId", "username", order_details.userId);
            return View(order_details);
        }

        // GET: Order_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_details order_details = db.Order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.User_details, "userId", "username", order_details.userId);
            return View(order_details);
        }

        // POST: Order_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderId,userId,orderInfo,fromCity,toCity,departureDate,returnDate,peopleNumber,payment")] Order_details order_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.User_details, "userId", "username", order_details.userId);
            return View(order_details);
        }

        // GET: Order_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_details order_details = db.Order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            return View(order_details);
        }

        // POST: Order_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_details order_details = db.Order_details.Find(id);
            db.Order_details.Remove(order_details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
