using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyncModel.Models
{
    public class Files
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime Data { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }
        public byte[] FileContent { get; set; }

        public int UserId { get; set; }
          [ForeignKey("UserId")]
        public UserProfile User { get; set; }
    }
}