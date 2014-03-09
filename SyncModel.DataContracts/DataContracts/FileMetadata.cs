using System;
using System.Runtime.Serialization;

namespace SyncModel.SyncService.DataContracts
{
    [DataContract]
    public class FileMetadata
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public DateTime Data { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string FileType { get; set; }

        [DataMember]
        public int UserId { get; set; }
    }
}
