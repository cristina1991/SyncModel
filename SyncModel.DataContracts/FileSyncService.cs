using System.Linq;
using SyncModel.Data.Models;
using SyncModel.Data.Repositories;
using SyncModel.SyncService.DataContracts;
using WebMatrix.WebData;
using FileMetadata = SyncModel.SyncService.DataContracts.FileMetadata;

namespace SyncModel.SyncService
{
    public class FileSyncService : IFileSyncService
    {
        private readonly FilesRepository _filesRepository = new FilesRepository();

        public User Login(string username, string password)
        {
            if (WebSecurity.Login(username, password))
            {
                return new User
                {
                    UserId = WebSecurity.GetUserId(username),
                    Username = username
                };
            }

            return null;
        }

        public FileMetadataCollection GetFilesMetadataForUser(User user)
        {
            return
                new FileMetadataCollection(from fileMetadata in _filesRepository.GetFilesMetadataForUserId(user.UserId)
                    select
                        new FileMetadata
                        {
                            Data = fileMetadata.LastDateChanged,
                            Description = fileMetadata.Description,
                            FileName = fileMetadata.FileName,
                            FileType = fileMetadata.FileType,
                            Id = fileMetadata.Id,
                            UserId = fileMetadata.UserId
                        });
        }

        /// <summary>
        ///     Upload new files.
        /// </summary>
        /// <param name="content"></param>
        public void UploadFile(FileSyncContent content)
        {
            _filesRepository.InsertFile(new File
            {
                Data = content.Data,
                Description = content.Description,
                FileContent = content.FileContent,
                FileName = content.FileName,
                FileType = content.FileType,
                UserId = content.UserId
                
            });
        }

        /// <summary>
        ///     Download new files uploaded using the website.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public FileSyncContent DownloadFile(FileMetadata metadata)
        {
            File file = _filesRepository.GetFileById(metadata.Id);

            return new FileSyncContent
            {
                Data = file.Data,
                Description = file.Description,
                FileContent = file.FileContent,
                FileName = file.FileName,
                FileType = file.FileType,
                Id = file.Id,
                UserId = file.UserId
            };
        }

        public void UploadEditedFile(FileSyncContent content)
        {
            _filesRepository.EditFile(new File
            {
                Data = content.Data,
                Description = content.Description,
                FileContent = content.FileContent,
                FileName = content.FileName,
                FileType = content.FileType,
                Id = content.Id,
                UserId = content.UserId
            });
        }
        public void DeleteFile(FileSyncContent content)
        {
            _filesRepository.DeleteFile(new File
            {
                Data = content.Data,
                Description = content.Description,
                FileContent = content.FileContent,
                FileName = content.FileName,
                FileType = content.FileType,
                Id = content.Id,
                UserId = content.UserId
            });
        }
    }
}