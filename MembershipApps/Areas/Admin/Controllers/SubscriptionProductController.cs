using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MembershipApps.Models;
using MembershipApps.ViewModel;
using Memberships.Entities;

namespace MembershipApps.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubscriptionProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/SubscriptionProduct
        public async Task<ActionResult> Index()
        {
            var subscriptionProducts = db.SubscriptionProducts.Include(s => s.Product).Include(s => s.Subscription);
            return View(await subscriptionProducts.ToListAsync());
        }

        // GET: Admin/SubscriptionProduct/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionProduct subscriptionProduct = await db.SubscriptionProducts.FindAsync(id);
            if (subscriptionProduct == null)
            {
                return HttpNotFound();
            }

            var viewModel = new SubscriptionProductViewModel
            {
                Products = db.Products.ToList(),
                Subscriptions = db.Subscriptions.ToList(),
                SubscriptionProduct = db.SubscriptionProducts.SingleOrDefault(sp => sp.Id == id)
            };
            return View(viewModel);
        }

        // GET: Admin/SubscriptionProduct/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title");
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "Id", "Title");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductId,SubscriptionId")] SubscriptionProduct subscriptionProduct)
        {
            if (ModelState.IsValid)
            {
                db.SubscriptionProducts.Add(subscriptionProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", subscriptionProduct.ProductId);
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "Id", "Title", subscriptionProduct.SubscriptionId);
            return View(subscriptionProduct);
        }

        // GET: Admin/SubscriptionProduct/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionProduct subscriptionProduct = await db.SubscriptionProducts.FindAsync(id);
            if (subscriptionProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", subscriptionProduct.ProductId);
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "Id", "Title", subscriptionProduct.SubscriptionId);
            return View(subscriptionProduct);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductId,SubscriptionId")] SubscriptionProduct subscriptionProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriptionProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", subscriptionProduct.ProductId);
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "Id", "Title", subscriptionProduct.SubscriptionId);
            return View(subscriptionProduct);
        }

        // GET: Admin/SubscriptionProduct/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionProduct subscriptionProduct = await db.SubscriptionProducts.FindAsync(id);
            if (subscriptionProduct == null)
            {
                return HttpNotFound();
            }
            var viewModel = new SubscriptionProductViewModel
            {
                Products = db.Products.ToList(),
                Subscriptions = db.Subscriptions.ToList(),
                SubscriptionProduct = db.SubscriptionProducts.SingleOrDefault(sp => sp.Id == id)
            };
            return View(viewModel);
        }

        // POST: Admin/SubscriptionProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubscriptionProduct subscriptionProduct = await db.SubscriptionProducts.FindAsync(id);
            db.SubscriptionProducts.Remove(subscriptionProduct);
            await db.SaveChangesAsync();
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
