using System;
using System.Collections.Generic;
using System.Linq;
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
                    oldFile.FileContent = file.FileContent;
                    oldFile.FileType = file.FileType;                   
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

        public List<FileMetadata> GetFilesMetadataForUserId(int userId)
        {
            using (var context = new FilesContext())
            {
                return (from file in context.Fisiere
                    where file.UserId == userId
                    select new FileMetadata() {Description = file.Description,FileName = file.FileName,FileType = file.FileType,UserId = file.UserId,Id = file.Id,LastDateChanged = file.Data}).ToList();
            }
        }
    }
}
