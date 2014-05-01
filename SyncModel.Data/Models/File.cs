﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyncModel.Data.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime Data { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }
        public byte[] FileContent { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserProfile User { get; set; }
    }
}