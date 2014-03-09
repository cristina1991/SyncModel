using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using SyncModel.Data.Models;
using SyncModel.Data.Repositories;
using File = SyncModel.Data.Models.File;

namespace SyncModel.Controllers
{
    [Authorize]
    public class FilesController : Controller
    {
        private readonly FilesRepository _filesRepository = new FilesRepository();
        private readonly UsersRepository _usersRepository = new UsersRepository();
        //
        // GET: /Files/

        public ActionResult Index()
        {

            UserProfile user = _usersRepository.GetUserProfileByName(User.Identity.Name);
            
            // Check if user already exists
            if (user != null)
            {
                var usersFiles =_filesRepository.GetFilesForUserProfile(user);
                return View(usersFiles);
            }

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Files/Details/5

        public ActionResult Details(int id = 0)
        {
            var file = _filesRepository.GetFileById(id);

            if (file == null)
            {
                return HttpNotFound();
            }

            return View(file);
        }

        //
        // GET: /Files/Create

        public ActionResult Create()
        {
            return View();
        }

        ////
        //// POST: /Files/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(File file)
        //{
        //    if (ModelState.IsValid)
        //    {
        //       UserProfile user = _usersRepository.GetUserProfileByName(User.Identity.Name);

        //        _filesRepository.Create()
        //        return RedirectToAction("Index");
        //    }

        //    return View(files);
        //}

        //
        // GET: /Files/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var file = _filesRepository.GetFileById(id);

            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        //
        // POST: /Files/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(File file)
        {
            if (ModelState.IsValid)
            {
                //make sure the edited file has the same user profile assigned to it
                file.User = _usersRepository.GetUserProfileByName(User.Identity.Name.ToLower());
                file.Data = DateTime.Now;
                //save the changes
                _filesRepository.EditFile(file);        
        
                return RedirectToAction("Index");
            }
            return View(file);
        }

        //
        // GET: /Files/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var file = _filesRepository.GetFileById(id);
            var userProfile = _usersRepository.GetUserProfileByName(User.Identity.Name.ToLower());

            if (file == null || userProfile == null)
            {
                return HttpNotFound();
            }
            
            return View(file);
        }

        //
        // POST: /Files/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var file = _filesRepository.GetFileById(id);
            var userProfile = _usersRepository.GetUserProfileByName(User.Identity.Name.ToLower());

            if (file == null || userProfile == null)
            {
                return HttpNotFound();
            }

            if (file.UserId == userProfile.UserId)
            {
                _filesRepository.DeleteFile(file);
            }

            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Upload")]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase fisier)
        {
            if (fisier != null && fisier.ContentLength > 0)
            {
                var userProfile = _usersRepository.GetUserProfileByName(User.Identity.Name.ToLower());
                var newFile = new File
                {
                    Data = DateTime.Now,
                    Description = fisier.FileName,
                    FileName = fisier.FileName,
                    FileType = fisier.ContentType,
                    UserId = userProfile.UserId
                };

                using (var binaryReader = new BinaryReader(fisier.InputStream))
                {
                    newFile.FileContent = binaryReader.ReadBytes(fisier.ContentLength);
                }

                _filesRepository.InsertFile(newFile);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Download(int id)
        {
            var downloadFile = _filesRepository.GetFileById(id);

            if (downloadFile != null)
            {
                return File(downloadFile.FileContent, System.Net.Mime.MediaTypeNames.Application.Octet, downloadFile.FileName);
            }

            return HttpNotFound();
        }
    }
}