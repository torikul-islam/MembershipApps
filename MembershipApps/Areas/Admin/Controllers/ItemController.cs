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
using Memberships.Entities;
using MembershipApps.ViewModel;

namespace MembershipApps.Areas.Admin.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Item
        public async Task<ActionResult> Index()
        {
            return View(await db.Items.ToListAsync());
        }

        // GET: Admin/Item/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Admin/Item/Create
        public ActionResult Create()
        {
            var viewModel = new ItemViewModel
            {
                Parts = db.Parts.ToList(),
                Sections = db.Sections.ToList(),
                ItemTypes = db.ItemTypes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var viewModel = new ItemViewModel
            {
                Parts = db.Parts.ToList(),
                Sections = db.Sections.ToList(),
                ItemTypes = db.ItemTypes.ToList(),
            };
            return View(viewModel);
        }

        // GET: Admin/Item/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var viewModel = new ItemViewModel
            {
                Parts = db.Parts.ToList(),
                Sections = db.Sections.ToList(),
                ItemTypes = db.ItemTypes.ToList(),
                Item  = await db.Items.FindAsync(id)
            };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Item item)
        {
            if (ModelState.IsValid)
            {
               db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var viewModel = new ItemViewModel
            {
                Parts = db.Parts.ToList(),
                Sections = db.Sections.ToList(),
                ItemTypes = db.ItemTypes.ToList(),
                Item = await db.Items.FindAsync(item.Id)
            };
            return View(viewModel);
        }

        // GET: Admin/Item/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Admin/Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
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
