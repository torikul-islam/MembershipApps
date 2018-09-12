using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using MembershipApps.Models;
using MembershipApps.ViewModel;
using Memberships.Entities;

namespace MembershipApps.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Product
        public async Task<ActionResult> Index()
        {
            var viewModel =  db.Products.Include(pt => pt.ProductType).Include(plt => plt.ProductLinkText).ToListAsync();
            return View( await viewModel);

            //return View(await db.Products.ToListAsync());
        }

        // GET: Admin/Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                ProductLinkTexts = db.ProductLinkTexts.ToList(),
                ProductTypes = db.ProductTypes.ToList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var viewModel = new ProductViewModel
            {
                ProductLinkTexts = db.ProductLinkTexts.ToList(),
                ProductTypes = db.ProductTypes.ToList(),
            };
            return View(viewModel);
        }

        // GET: Admin/Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new ProductViewModel
            {
                ProductLinkTexts = db.ProductLinkTexts.ToList(),
                ProductTypes = db.ProductTypes.ToList(),
                Product = db.Products.SingleOrDefault(p=> p.Id == id)
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var viewModel = new ProductViewModel
            {
                ProductLinkTexts = db.ProductLinkTexts.ToList(),
                ProductTypes = db.ProductTypes.ToList(),
                Product = db.Products.SingleOrDefault(p => p.Id == product.Id)
            };
            return View( viewModel);
        }

        // GET: Admin/Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
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
