using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TheForum.Models;

namespace TheForum.Controllers
{
    public class TheForumController : Controller
    {

        private TheForum.Models.TheForumContext _db = new TheForum.Models.TheForumContext();
        // GET: TheForum
        public ActionResult Index()
        {
            var mostRecentEntries =
                (from entry in _db.Entries
                 orderby entry.DateAdded descending
                 select entry).Take(20);
            ViewBag.Entries = mostRecentEntries.ToList();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TheForum.Models.TheForumEntry entry)
        {
            entry.DateAdded = DateTime.Now;
            _db.Entries.Add(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ViewResult Show(int id)
        {
            var entry = _db.Entries.Find(id);
            bool hasPermission = User.Identity.Name == entry.Name;
            ViewData["hasPermission"] = hasPermission;
            return View(entry);
        }

        public ActionResult CommentSummary()
        {
            var entries = from entry in _db.Entries
                          group entry by entry.Name
                              into groupedByName
                          orderby groupedByName.Count() descending
                          select new TheForum.Models.CommentSummary
                          {
                              NumberOfComments =
                                              groupedByName.Count(),
                              UserName = groupedByName.Key
                          };
            return View(entries.ToList());
        }

        public ActionResult Edit(int id)
        {
            var entry = _db.Entries.Find(id);
            return View(entry);
        }

        [HttpPost]
        public ActionResult Edit(TheForum.Models.TheForumEntry entry)
        {
            /* _db.Entries.Attach(entry);
             _db.Entry(entry).State = System.Data.Entity.EntityState.Modified;
             _db.SaveChanges();
             return RedirectToAction("Index"); */
            var editEntry = _db.Entries.Find(entry.Id);
            editEntry.Message = entry.Message;
            _db.Entry(editEntry).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            var entry = _db.Entries.Find(id);
            if (User.Identity.Name == entry.Name)
                return View(entry);
            else
                return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult
        DeleteConfirmed(TheForum.Models.TheForumEntry entry)
        {
            var editEntry = _db.Entries.Find(entry.Id);
            if (User.Identity.Name == editEntry.Name)
            {
                _db.Entries.Remove(editEntry);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}