using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileMVC.Models;
using System.IO;

namespace FileMVC.Controllers
{
    [Authorize]
    public class FilesController : Controller
    {
        private FileMVCdb db = new FileMVCdb();

        //
        // GET: /Files/

        public ActionResult Index()
        {
     
                UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == User.Identity.Name.ToLower());
                // Check if user already exists
                if (user != null)
                {
                    return View(db.fisiere.Where<Files>(c => c.UserId==user.UserId).ToList());
                }
            

            return View();
        }

        //
        // GET: /Files/Details/5

        public ActionResult Details(int id = 0)
        {
            Files files = db.fisiere.Find(id);
            if (files == null)
            {
                return HttpNotFound();
            }
            return View(files);
        }

        //
        // GET: /Files/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Files/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Files files)
        {
            if (ModelState.IsValid)
            {
                db.fisiere.Add(files);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(files);
        }

        //
        // GET: /Files/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Files files = db.fisiere.Find(id);
            if (files == null)
            {
                return HttpNotFound();
            }
            return View(files);
        }

        //
        // POST: /Files/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Files files)
        {
            if (ModelState.IsValid)
            {
                db.Entry(files).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(files);
        }

        //
        // GET: /Files/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Files files = db.fisiere.Find(id);
            if (files == null)
            {
                return HttpNotFound();
            }
            return View(files);
        }

        //
        // POST: /Files/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Files files = db.fisiere.Find(id);
            db.fisiere.Remove(files);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Upload")]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase fisier)
        {
            if (fisier != null && fisier.ContentLength > 0)
            {
               
                Files newFile = new Files();
                newFile.Data = DateTime.Now;
                newFile.Description = fisier.FileName;
                newFile.FileName = fisier.FileName;
                newFile.FileType = fisier.ContentType;
                using (var binaryReader = new BinaryReader(fisier.InputStream))
                {
                    newFile.FileContent = binaryReader.ReadBytes(fisier.ContentLength);
                }
                using (var context = new FileMVCdb())
                {
                    var user = context.UserProfiles.First(u => u.UserName == User.Identity.Name);
                    newFile.User = user;
                    context.fisiere.Add(newFile);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Download(int id)
        {
            Files downloadFile = db.fisiere.FirstOrDefault<Files>(f=>f.Id==id);
            if (downloadFile != null)
            {
                return File(downloadFile.FileContent, System.Net.Mime.MediaTypeNames.Application.Octet, downloadFile.FileName);
            }
            return View();
        }
       

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}