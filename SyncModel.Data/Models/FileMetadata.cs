using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncModel.Data.Models
{
    public class FileMetadata
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime LastDateChanged { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }

        public int UserId { get; set; }
    }
}
