using System.Runtime.Serialization;

namespace SyncModel.SyncService.DataContracts
{
    [DataContract]
    public class FileSyncContent
        : FileMetadata
    {
        [DataMember]
        public byte[] FileContent { get; set; }
    }
}
