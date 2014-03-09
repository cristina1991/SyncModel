using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncModel.Data.DataContexts;
using SyncModel.Data.Models;

namespace SyncModel.Data.Repositories
{
    public class FilesRepository
    {
        public List<File> GetFilesForUserProfile(UserProfile userProfile)
        {
            if (userProfile == null)
            {
                throw new ArgumentNullException("userProfile");
            }

            if (userProfile.UserId == 0)
            {
                throw new ArgumentException();
            }

            using (var context = new FilesContext())
            {
                return context.Fisiere.Where<File>(c => c.UserId == userProfile.UserId).ToList();
            }
        }

        public File GetFileById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("id");
            }

            using (var context = new FilesContext())
            {
                return context.Fisiere.FirstOrDefault(c => c.Id == id);
            }
        }

        public void EditFile(File file)
        {
            using (var context = new FilesContext())
            {
                var oldFile = context.Fisiere.FirstOrDefault(c => c.Id == file.Id && c.UserId == file.User.UserId);
                
                if (oldFile != null)
                {
                    oldFile.Data = file.Data;
                    oldFile.Description = file.Description;
                    oldFile.FileName = file.FileName;
                }

                context.SaveChanges();
            }
        }

        public void DeleteFile(File file)
        {
            using (var context = new FilesContext())
            {
                context.Fisiere.Attach(file);
                context.Fisiere.Remove(file);
                context.SaveChanges();
            }
        }

        public void InsertFile(File file)
        {
            using (var context = new FilesContext())
            {
                context.Fisiere.Add(file);
                context.SaveChanges();
            }
        }
    }
}
