using System.ServiceModel;
using SyncModel.SyncService.DataContracts;

namespace SyncModel.SyncService
{    
    [ServiceContract]
    public interface IFileSyncService
    {
        [OperationContract]
        User Login(string username, string password);

        [OperationContract]
        FileMetadataCollection GetFilesMetadataForUser(User user);

        [OperationContract]
        void UploadFile(FileSyncContent content);

        [OperationContract]
        FileSyncContent DownloadFile(FileMetadata metadata);

        [OperationContract]
        void UploadEditedFile(FileSyncContent content);
    }
}
