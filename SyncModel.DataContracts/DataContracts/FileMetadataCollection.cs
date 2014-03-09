using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SyncModel.SyncService.DataContracts
{
    [CollectionDataContract]
    public class FileMetadataCollection
         : List<FileMetadata>
    {
        public FileMetadataCollection()
        {
        }

        public FileMetadataCollection(IEnumerable<FileMetadata> metadatas)
            : base(metadatas)
        {
        }
    }
}
