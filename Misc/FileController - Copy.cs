using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PartsR2.DAL;
using PartsR2.Models;
using PartsR2.ViewModels;

namespace PartsR2.Controllers
{
    public class FileController : Controller
    {
        private PRContext db = new PRContext();

        // GET: File
        // ***** ORIGINAL ActionResult Index Data Starts Here *******
      //  public ActionResult Index()
      //  {
      //      return View(db.Files.ToList());
      //  }
      // ******* Original ActionResult Index Data Ends Here ********

            public ActionResult Index(int? id, int? quoteID)
        {
            var viewModel = new FileIndexData();
            viewModel.Files = db.Files
                .Include(i => i.Quotes);

            if (id != null)
            {
                ViewBag.FileID = id.Value;
                viewModel.Quotes = viewModel.Files.Where(
                    i => i.FileID == id.Value).Single().Quotes;

            }

            if (quoteID != null)
            {
                ViewBag.QuoteID = quoteID.Value;
                viewModel.Parts = viewModel.Quotes.Where(
                   x => x.QuoteID == quoteID).Single().Parts;
            
            }

            return View(viewModel);
        }
        // GET: File/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // GET: File/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: File/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FileID,ResearchReqFile,DateResearchAssigned,PriorityLevel,StatusLevel")] File file)
        {
            if (ModelState.IsValid)
            {
                db.Files.Add(file);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(file);
        }

        // GET: File/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // POST: File/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FileID,ResearchReqFile,DateResearchAssigned,PriorityLevel,StatusLevel")] File file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(file).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(file);
        }

        // GET: File/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // POST: File/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            File file = db.Files.Find(id);
            db.Files.Remove(file);
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
